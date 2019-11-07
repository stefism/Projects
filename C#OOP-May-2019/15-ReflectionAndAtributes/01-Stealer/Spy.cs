using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;


    public class Spy
    {
        public string StealFieldInfo(string inputClassName, params string[] fields)
        {
            var sb = new StringBuilder();

            Type findingClass = Type.GetType($"{inputClassName}");
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

