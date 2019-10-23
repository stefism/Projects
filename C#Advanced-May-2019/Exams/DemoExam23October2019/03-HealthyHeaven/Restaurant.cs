using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HealthyHeaven
{
    public class Restaurant
    {
        private int data => Salads.Count;

        public Restaurant(string name)
        {
            Name = name;
            Salads = new List<Salad>();
        }

        public List<Salad> Salads { get; private set; }
        public string Name { get; private set; }

        public void Add(Salad salad)
        {
            Salads.Add(salad);
        }

        public bool Buy(string name)
        {
            Salad saladToRemove = Salads.FirstOrDefault(x => x.Name == name);

            if (saladToRemove == null)
            {
                return false;
            }

            Salads.Remove(saladToRemove);
            return true;
        }

        public Salad GetHealthiestSalad()
        {
            return Salads.OrderBy(x => x.GetTotalCalories()).First();
        }

        public string GenerateMenu()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Name} have {data} salads:");

            foreach (var sal in Salads)
            {
                sb.AppendLine(sal.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
