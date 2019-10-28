using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_MakeASalad
{
    class Program
    {
        static void Main(string[] args)
        {
            const int TOMATO_CAL = 80;
            const int CARROT_CAL = 136;
            const int LETTUCE_CAL = 109;
            const int POTATO_CAL = 215;

            Queue<string> vegetables = new Queue<string>(Console.ReadLine().Split());

            Stack<int> calories = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            Stack<int> makedCalories = new Stack<int>(calories.Reverse());

            List<int> makedCaloriesList = new List<int>();

            while (vegetables.Count > 0 && calories.Count > 0)
            {
                string currVegetable = vegetables.Dequeue();
                int currentCalories = calories.Pop();

                if (currVegetable == "tomato")
                {
                    currentCalories -= TOMATO_CAL;
                }
                else if (currVegetable == "potato")
                {
                    currentCalories -= POTATO_CAL;
                }
                else if (currVegetable == "carrot")
                {
                    currentCalories -= CARROT_CAL;
                }
                else if (currVegetable == "lettuce")
                {
                    currentCalories -= LETTUCE_CAL;
                }

                if (currentCalories > 0)
                {
                    calories.Push(currentCalories);
                   
                    if (vegetables.Count == 0)
                    {
                        makedCaloriesList.Add(makedCalories.Pop());
                        calories.Pop();
                    }
                }
                else
                {
                    makedCaloriesList.Add(makedCalories.Pop());
                }

                //if (vegetables.Count == 0 && calories.Count > 0)
                //{
                //    makedCaloriesList.Add(makedCalories.Pop());
                //    calories.Pop();
                //}
            }

            Console.WriteLine(string.Join(" ", makedCaloriesList));

            if (vegetables.Count == 0)
            {
                Console.WriteLine(string.Join(" ", calories));
            }
            else
            {
                Console.WriteLine(string.Join(" ", vegetables));
            }
        }
    }
}
