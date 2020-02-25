using System;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());

            // 1. Първата и втората клетка да са от А до B
            // 2. Третата и четвъртата клетка да са от С до D
            // 3. Първата + 4тата да е = втората + 3тата
            // 4. Първата да е различна от втората
            // 5. Третата да е различна от 4тата

            for (int aNumber = a; aNumber <= b; aNumber++)
            {
                for (int bNumber = a; bNumber <= b; bNumber++)
                {
                    for (int cNumber = c; cNumber <= d; cNumber++)
                    {
                        for (int dNumber = c; dNumber <= d; dNumber++)
                        {
                            bool equalSum = aNumber + dNumber == bNumber + cNumber;
                            bool diffAB = aNumber != bNumber;
                            bool diffCD = cNumber != dNumber;

                            if (equalSum && diffAB && diffCD)
                            {
                                Console.WriteLine("" + aNumber + bNumber);
                                Console.WriteLine("" + cNumber + dNumber);
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }
        }
    }
}
