using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04_Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            var dwarfs = new List<Dwarfs>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(" <:> ");

                string name = input[0];

                if (name == "Once upon a time")
                {

                    Console.WriteLine(string.Join(Environment.NewLine, dwarfs
                        .OrderByDescending(x => x.Physics).ThenByDescending(x => x.HatColor.Count())
                        .Select(x => $"{x.HatColor} {x.Name} <-> {x.Physics}")));

                    //Console.WriteLine(string.Join(Environment.NewLine, dwarfs
                    //    .OrderByDescending(x => x.Physics).ThenByDescending(x => x.HatColor.Count())
                    //    .Select(x => $"{x.HatColor} {x.Name} <-> {x.Physics}")));
                    break;
                }

                string hatColor = "(" + input[1] + ")";
                int physics = int.Parse(input[2]);

                if (dwarfs.Count == 0)
                {
                    dwarfs.Add(new Dwarfs { Name = name, HatColor = hatColor, Physics = physics });
                }
                else
                {
                    foreach (var item in dwarfs)
                    {
                        if (item.Name == name)
                        {
                            if (item.HatColor == hatColor)
                            {
                                if (item.Physics < physics)
                                {
                                    item.Physics = physics;
                                    break;
                                }
                            }
                            else
                            {
                                dwarfs.Add(new Dwarfs { Name = name, HatColor = hatColor, Physics = physics });
                                break;
                            }
                        }
                        else
                        {
                            dwarfs.Add(new Dwarfs { Name = name, HatColor = hatColor, Physics = physics });
                            break;
                        }
                    }
                }
            }
        }
    }

    class Dwarfs
    {
        public string Name { get; set; }
        public string HatColor { get; set; }
        public int Physics { get; set; }
    }
}
