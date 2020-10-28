using System;

namespace SecretDoor
{
    class Program
    {
        static void Main(string[] args)
        {
            int hundreds = int.Parse(Console.ReadLine());
            int tens = int.Parse(Console.ReadLine());
            int units = int.Parse(Console.ReadLine());

            for (int n1 = 1; n1 <= hundreds; n1++)
            {
                for (int n2 = 1; n2 <= tens; n2++)
                {

                    for (int n3 = 1; n3 <= units; n3++)
                    {
                       if (n1 % 2 == 0 && (n2 == 2 || n2 == 3 || n2 == 5 || n2 == 7) && n3 % 2 == 0)
                        {
                            Console.WriteLine($"{n1} {n2} {n3}");
                        }

                        //if (n2 == 2 || n2 == 3 || n2 == 5 || n2 == 7)
                        //{
                        //    Console.Write(n2);
                        //}

                        //if (n3 % 2 == 0)
                        //{
                        //    Console.Write(n3);
                        //    Console.WriteLine();
                        //}
                    }
                }
            }
            
        }
    }
}
