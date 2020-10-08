using SUS.MvcFramework.ViewEngine;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SUS.MvcFramework
{
    public class SusViewEngine : IViewEngine
    {
        public string GetHtml(string templateCode, object viewModel)
        {
            string csharpCode = GenerateCSharpFromTemplate(templateCode);
            IView executableObject = GenerateExecutableCode(csharpCode);
            string html = executableObject.ExecuteTemplate(viewModel);
            return html;
        }

        private string GenerateCSharpFromTemplate(string templateCode)
        {
            string methodBody = GetMethodBody(templateCode);
            string scharpCode = @"
using System;
using System.Text;
using System.Linq;
using System.Collection.Generic;
using SUS.MvcFramework.ViewEngine;

namespace ViewNamespace
{
    public class ViewClass : IView
    {
        public string ExecuteTemplate(object viewModel)
        {
            var html = new StringBuilder();
            
            " + methodBody + @"

            return html.ToString();
        }        
    }
}
";
            return scharpCode;
        }

        private string GetMethodBody(string templateCode)
        {
            throw new NotImplementedException();
        }

        private IView GenerateExecutableCode(string csharpCode)
        {
            throw new NotImplementedException();
        }
    }
}
