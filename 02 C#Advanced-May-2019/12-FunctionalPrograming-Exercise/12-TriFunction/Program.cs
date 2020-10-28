using System;
using System.Collections.Generic;
using System.Linq;

namespace _12_TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> equalSum = (name, sum) 
                => name.Sum(x => x) >= sum; // Прави същото като долното но на един ред.
            
            //{
                
                //int sumName = 0;

                //for (int i = 0; i < name.Length; i++)
                //{
                //    sumName += name[i];
                //}

                //if (sumName >= sum)
                //{
                //    return true;
                //}

                //return false;
            //};

            int inputSum = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(string.Join(" ", names.FirstOrDefault(x => equalSum(x, inputSum))));
        }
    }
}
