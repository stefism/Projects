using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_EasterGifts
{
    class Program
    {
        static void Main(string[] args)
        {
            //Technology Fundamentals Retake Mid Exam - 16 April 2019

            List<string> gifts = Console.ReadLine().Split().ToList();

            while (true)
            {
                List<string> commands = Console.ReadLine().Split().ToList();

                if (commands[0] == "OutOfStock")
                {
                    //List<string> listOfStrings = new List<string> {"abc", "123", "ghi"};
                    //listOfStrings[listOfStrings.FindIndex(ind => ind.Equals("123"))] = "def";

                    while (gifts.Contains(commands[1]))
                    {
                        gifts[gifts.FindIndex(x => x.Equals(commands[1]))] = "None";
                    }
                    
                }

                else if (commands[0] == "Required")
                {
                    int index = int.Parse(commands[2]);

                    if (index >=0 && index <= gifts.Count-1)
                    {
                        gifts.RemoveAt(index);
                        gifts.Insert(index, commands[1]);
                    }
                }

                else if (commands[0] == "JustInCase")
                {
                    gifts.RemoveAt(gifts.Count-1);
                    gifts.Add(commands[1]);
                }

                else if (commands[0] == "No")
                {
                    foreach (var item in gifts)
                    {
                        if (item != "None")
                        {
                            Console.Write(item + " ");
                        }
                    }
                    //Console.WriteLine(string.Join(" ", gifts));
                    break;
                }
            }
        }
    }
}
