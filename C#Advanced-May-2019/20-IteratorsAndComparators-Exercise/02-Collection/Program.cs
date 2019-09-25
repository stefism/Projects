using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> create = Console.ReadLine().Split().ToList();

            ListyIterator<string> listyterator = new ListyIterator<string>();

            if (create.Count > 1)
            {
                create.RemoveAt(0);
                string[] array = create.ToArray();
                listyterator.Create(array);
            }
            else
            {
                listyterator.Create();
            }

            while (true)
            {
                try
                {
                    string command = Console.ReadLine();

                    if (command == "END")
                    {
                        break;
                    }

                    else if (command == "Move")
                    {
                        Console.WriteLine(listyterator.Move());
                    }

                    else if (command == "Print")
                    {
                        listyterator.Print();
                    }

                    else if (command == "HasNext")
                    {
                        Console.WriteLine(listyterator.HasNext());
                    }

                    else if (command == "PrintAll")
                    {
                        foreach (var item in listyterator)
                        {
                            Console.Write(item + " ");
                        }
                        Console.WriteLine();
                    }
                }
                catch (Exception exception)
                {

                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}
