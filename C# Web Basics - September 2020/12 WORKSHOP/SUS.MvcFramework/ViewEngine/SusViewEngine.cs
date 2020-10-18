using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using SUS.MvcFramework.ViewEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace SUS.MvcFramework
{
    public class SusViewEngine : IViewEngine
    {
        public string GetHtml(string templateCode, object viewModel, string user)
        {
            string csharpCode = GenerateCSharpFromTemplate
                (templateCode, viewModel);
            IView executableObject = GenerateExecutableCode
                (csharpCode, viewModel);
            string html = executableObject
                .ExecuteTemplate(viewModel, user);
            return html;
        }

        private string GenerateCSharpFromTemplate
            (string templateCode, object viewModel)
        {
            string typeOfModel = "object";

            if (viewModel != null)
            {
                if (viewModel.GetType().IsGenericType)
                {
                    string modelName = viewModel.GetType().FullName;

                    Type[] genericArguments = viewModel
                        .GetType().GenericTypeArguments;

                    typeOfModel = modelName
                        .Substring(0, modelName.IndexOf('`'))
                        + "<" + string.Join(",", genericArguments.Select(x => x.FullName)) + ">";
                }
                else
                {
                    typeOfModel = viewModel.GetType().FullName;
                }
            }            

            string scharpCode = @"
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using SUS.MvcFramework.ViewEngine;

namespace ViewNamespace
{
    public class ViewClass : IView
    {
        public string ExecuteTemplate(object viewModel, string user)
        {
            var User = user;
            var Model = viewModel as " + typeOfModel + @";
            var html = new StringBuilder();
            
            " + GetMethodBody(templateCode) + @"

            return html.ToString();
        }        
    }
}
";
            return scharpCode;
        }

        private string GetMethodBody(string templateCode)
        {
            Regex csharpCodeRegex = new Regex(@"[^\""\s&\'\<]+"); //Maybe ! need to insert in regex?

            var supportedOperators = new List<string>
            {
                "for", "while", "if", "else",  "foreach"
            };

            StringBuilder csharpCode = new StringBuilder();
            StringReader sr = new StringReader(templateCode);

            string line;

            while ((line = sr.ReadLine()) != null)
            {
                if (supportedOperators.Any(x =>
                line.TrimStart().StartsWith("@" + x)))
                {
                    int atSignLocation = line.IndexOf("@");
                    line = line.Remove(atSignLocation, 1);
                    csharpCode.AppendLine(line);
                }
                else if (line.TrimStart()
                    .StartsWith("{") || line.TrimStart().StartsWith("}"))
                {
                    csharpCode.AppendLine(line);
                }
                else
                {
                    csharpCode.Append($"html.AppendLine(@\"");

                    while (line.Contains("@"))
                    {
                        int atSignLocation = line.IndexOf("@");
                        string htmlBeforeSign = line.Substring(0, atSignLocation);
                        csharpCode
                            .Append(htmlBeforeSign.Replace("\"", "\"\"") + "\" + ");
                        string lineAfterSign = line.Substring(atSignLocation + 1);
                        string code = csharpCodeRegex.Match(lineAfterSign).Value;
                        csharpCode.Append(code + " + @\"");
                        line = lineAfterSign.Substring(code.Length);
                    }                    

                    csharpCode.AppendLine(line.Replace("\"", "\"\"") + "\");");
                }
            }

            return csharpCode.ToString();
        }

        private IView GenerateExecutableCode(string csharpCode, object viewModel)
        {
            var compileResult = CSharpCompilation.Create("ViewAssembly")
                .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
                .AddReferences(MetadataReference.CreateFromFile(typeof(object).Assembly.Location))
                .AddReferences(MetadataReference.CreateFromFile(typeof(IView).Assembly.Location));

            if (viewModel != null)
            {
                if (viewModel.GetType().IsGenericType)
                {
                    var genericArguments = viewModel.GetType().GenericTypeArguments;
                    foreach (var genericArgument in genericArguments)
                    {
                        compileResult = compileResult
                            .AddReferences(MetadataReference.CreateFromFile(genericArgument.Assembly.Location));
                    }
                }
                compileResult = compileResult
                    .AddReferences(MetadataReference
                    .CreateFromFile(viewModel.GetType().Assembly.Location));
            }

            AssemblyName[] libraries = Assembly.Load(new AssemblyName("netstandard"))
                .GetReferencedAssemblies();

            foreach (var library in libraries)
            {
                compileResult = compileResult
                    .AddReferences(MetadataReference
                    .CreateFromFile(Assembly.Load(library).Location));
            }

            compileResult = compileResult
                .AddSyntaxTrees(SyntaxFactory.ParseSyntaxTree(csharpCode));

            using (MemoryStream memoryStream = new MemoryStream())
            {
                EmitResult result = compileResult.Emit(memoryStream);

                if (!result.Success)
                {
                    return new ErrorView(result.Diagnostics
                        .Where(x => x.Severity == DiagnosticSeverity.Error)
                        .Select(x => x.GetMessage()), csharpCode);
                    ;
                }

                try
                {
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    //The stream works like audio cassette. We record to the any point and then if we want to listen the record, we have to go back to the beginning. Otherwise, we start reading from where the stream has reached. Therefore, with the above line we return to the beginning of the stream.

                    byte[] byteAssembly = memoryStream.ToArray();
                    Assembly assembly = Assembly.Load(byteAssembly);
                    Type viewType = assembly.GetType("ViewNamespace.ViewClass");
                    object instance = Activator.CreateInstance(viewType);
                    return (instance as IView)
                        ?? new ErrorView(new List<string> { "Instance is null!" }, csharpCode);
                    //If instance is null (not valid) - return error message.
                }
                catch (Exception ex)
                {
                    return new ErrorView(new List<string>
                    { ex.ToString()}, csharpCode);
                }
            }
        }
    }
}
