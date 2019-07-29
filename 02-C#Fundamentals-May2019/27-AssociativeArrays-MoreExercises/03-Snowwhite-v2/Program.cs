using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03_Snowwhite_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            var dwarfs = new Dictionary<string, List<Dwarf>>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(" <:> ");

                string name = input[0];

                if (name == "Once upon a time")
                {
                    foreach (var item in dwarfs)
                    {
                        List<Dwarf> values = item.Value;
                        //string itemKey = item.Key;

                        //foreach (var values in item.Value.OrderByDescending(x => x.Physics))
                        //{
                        //    Console.WriteLine($"{item.Key} {values.Name} <-> {values.Physics}");
                        //}

                        //Console.WriteLine(Environment.NewLine, item.Value
                        //    .Select(x => $"{itemKey} {x.Name} <-> {x.Physics}")); // Не печати нищо.
                           
                    }

                    break;
                }

                string hatColor = "(" + input[1] + ")";
                int physics = int.Parse(input[2]);

                if (!dwarfs.ContainsKey(hatColor))
                {
                    dwarfs[hatColor] = new List<Dwarf> { new Dwarf { Name = name, Physics = physics } }; // Нямаме обли скоби когато напрво тук добавяме.
                }
                else
                {
                    foreach (var item in dwarfs)
                    {
                        if (item.Key == hatColor)
                        {
                            if (item.Value.Any(x => x.Name == name))
                            {
                                Dwarf value = item.Value.FirstOrDefault(x => x.Name == name);

                                if (value.Physics < physics)
                                {
                                    value.Physics = physics;
                                    break;
                                }
                            }
                            else
                            {
                                dwarfs[hatColor].Add(new Dwarf { Name = name, Physics = physics });
                                break;
                            }
                        }
                    }
                }
            }
        }
    }

    class Dwarf
    {
        public string Name { get; set; }
        public int Physics { get; set; }
    }
}
