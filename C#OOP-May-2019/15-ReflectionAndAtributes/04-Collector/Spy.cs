using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace Spy
{
    public class Spy
    {
        StringBuilder sb = new StringBuilder();

        public string CollectGettersAndSetters(string inputClassName)
        {
            Type findingClass = Type.GetType($"Spy.{inputClassName}");

            MethodInfo[] classMethods = findingClass.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (var method in classMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (var method in classMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }

            return sb.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string inputClassName)
        {
            Type findingClass = Type.GetType($"Spy.{inputClassName}");

            MethodInfo[] classNonPublicMethods = findingClass.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            sb.AppendLine($"All private Methods of Class: {inputClassName}");
            sb.AppendLine($"Base Class: {findingClass.BaseType.Name}");

            foreach (var method in classNonPublicMethods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().TrimEnd();
        }

        public string AnalyzeAcessModifiers(string inputClassName)
        {
            Type findingClass = Type.GetType($"Spy.{inputClassName}");

            FieldInfo[] classFields = findingClass.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

            MethodInfo[] classPublicMethods = findingClass.GetMethods(BindingFlags.Instance | BindingFlags.Public);

            MethodInfo[] classNonPublicMethods = findingClass.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var field in classFields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            foreach (var method in classPublicMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }

            foreach (var method in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }

            return sb.ToString().TrimEnd();
        }

        public string StealFieldInfo(string inputClassName, params string[] fields)
        {
            

            Type findingClass = Type.GetType($"Spy.{inputClassName}");
            FieldInfo[] classFields = findingClass.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);

            sb.AppendLine($"Class under investigation: {findingClass.Name}");

            //classFields = (FieldInfo)classFields.Where(f => fields.Contains(f.Name));

            Object classInstance = Activator.CreateInstance(findingClass, null);

            foreach (FieldInfo field in classFields.Where(f => fields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
