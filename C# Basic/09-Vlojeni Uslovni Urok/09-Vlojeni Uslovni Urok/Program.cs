using System;

namespace _09_Vlojeni_Uslovni_Urok
{
    class Program
    {
        static void Main(string[] args)
        {
            double age = double.Parse(Console.ReadLine());
            string maleOrFemale = Console.ReadLine();
            char proba = char.Parse(Console.ReadLine());

            if (maleOrFemale == "m")
            {
                if (age >= 16)
                {
                    Console.WriteLine("Mr.");
                }
                else
                    Console.WriteLine("Master");

            }
            else if (maleOrFemale == "f")
            {
                if (age >= 16)
                {
                    Console.WriteLine("Ms.");
                }
                else
                    Console.WriteLine("Miss");
            }

        }
    }
}
