using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HealthyHeaven
{
    public class Salad
    {
        private readonly List<Vegetable> vegetables;
        public Salad(string name)
        {
            Name = name;
            vegetables = new List<Vegetable>();
        }

        public string Name { get; private set; }

        public IReadOnlyCollection<Vegetable> Vegetables => vegetables;

        public int GetTotalCalories()
        {
            return vegetables.Select(x => x.Calories).Sum();
        }

        public int GetProductCount()
        {
            int count = Vegetables.Count;

            return count;
        }

        public void Add(Vegetable vegetable)
        {
            vegetables.Add(vegetable);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            int calories = GetTotalCalories();

            sb.AppendLine($"* Salad {Name} is {calories} calories and have {calories} products:");

            foreach (var veg in vegetables)
            {
                sb.AppendLine(veg.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
