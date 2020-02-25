using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_EasterShopping
{
    class Program
    {
        static void Main(string[] args)
        {
            //Technology Fundamentals Retake Mid Exam - 16 April 2019

            List<string> shops = Console.ReadLine().Split().ToList();
            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                List<string> commands = Console.ReadLine().Split().ToList();

                if (commands[0] == "Include")
                {
                    shops.Add(commands[1]);
                }

                else if (commands[0] == "Visit")
                {
                    int numberOfShops = int.Parse(commands[2]);

                    if (numberOfShops <= shops.Count)
                    {
                        for (int j = 0; j < numberOfShops; j++)
                        {
                            if (commands[1] == "first")
                            {
                                shops.RemoveAt(0);
                            }
                            else if (commands[1] == "last")
                            {
                                shops.RemoveAt(shops.Count-1);
                            }
                        }
                    }
                }

                else if (commands[0] == "Prefer")
                {
                    int shopIndex1 = int.Parse(commands[1]);
                    int shopIndex2 = int.Parse(commands[2]);

                    if (shopIndex1 >=0 && shopIndex1 <= shops.Count-1 && shopIndex2 >= 0 && shopIndex2 <= shops.Count - 1)
                    {
                        string shopName1 = shops[shopIndex1];
                        string shopName2 = shops[shopIndex2];

                        if (shopIndex1 > shopIndex2)
                        {
                            shops.RemoveAt(shopIndex1);
                            shops.RemoveAt(shopIndex2);

                            shops.Insert(shopIndex2, shopName1);
                            shops.Insert(shopIndex1, shopName2);
                        }
                        else
                        {
                            shops.RemoveAt(shopIndex2);
                            shops.RemoveAt(shopIndex1);

                            shops.Insert(shopIndex1, shopName2);
                            shops.Insert(shopIndex2, shopName1);
                        }
                    }
                }

                else if (commands[0] == "Place")
                {
                    int shopIndex = int.Parse(commands[2]);

                    if (shopIndex+1 >= 0 && shopIndex+1 <= shops.Count-1)
                    {
                        shops.Insert(shopIndex+1, commands[1]);
                    }
                }
            }

            Console.WriteLine("Shops left:");
            Console.WriteLine(string.Join(" ", shops));
        }
    }
}
