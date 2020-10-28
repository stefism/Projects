using System;

namespace CarNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int startInterval = int.Parse(Console.ReadLine());
            int endInterval = int.Parse(Console.ReadLine());

            for (int n1 = startInterval; n1 <= endInterval; n1++)
            {
                for (int n2 = startInterval; n2 <= endInterval; n2++)
                {
                    for (int n3 = startInterval; n3 <= endInterval; n3++)
                    {
                        for (int n4 = startInterval; n4 <= endInterval; n4++)
                        {
                            if (n1 % 2 == 0)
                            {
                                if (n4 % 2 == 1)
                                {
                                    if (n1 > n4)
                                    {
                                        if ((n2 + n3) % 2 == 0)
                                        {
                                            Console.Write("" + n1 + n2 + n3 + n4 + " ");
                                        }
                                    }
                                }
                            }
                            else if (n1 % 2 == 1)
                            {
                                if (n4 % 2 == 0)
                                {
                                    if (n1 > n4)
                                    {
                                        if ((n2 + n3) % 2 == 0)
                                        {
                                            Console.Write("" + n1 + n2 + n3 + n4 + " ");
                                        }
                                        
                                    }
                                }
                            }    
                        }
                    }
                }
            }
        }
    }
}
