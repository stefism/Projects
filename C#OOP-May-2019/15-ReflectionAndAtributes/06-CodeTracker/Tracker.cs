using System;
using System.Reflection;
using System.Linq;

namespace _06_CodeTracker
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);
            MethodInfo[] methods = type.GetMethods
                (BindingFlags.Instance | BindingFlags.Public |
                BindingFlags.Static);

            foreach (var method in methods)
            {
                if (method.CustomAttributes
                    .Any(x => x.AttributeType == typeof(AuthorAttribute)))
                {
                    object[] attributes = method.GetCustomAttributes(false);

                    foreach (AuthorAttribute attr in attributes)
                    {
                        Console.WriteLine($"{method.Name} is written by {attr.Name}");
                    }
                }
            }
        }
    }
}
