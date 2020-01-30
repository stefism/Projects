using SoftUni.Data;
using System;
using System.Linq;

namespace Proba
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var result = context.Employees
                .Where(e => e.Address.Town.Name == "Seattle")
                .ToList();

            foreach (var empl in result)
            {
                empl.AddressId = null;
            }

            context.SaveChanges();

            var addresses = context.Addresses
                .Where(a => a.TownId == 4).ToList();

            context.RemoveRange(addresses);

            context.SaveChanges();

            var town = context.Towns
                .First(t => t.Name == "Seattle");

            context.Remove(town);

            context.SaveChanges();

            return $"{result.Count()} addresses in Seattle were deleted";
        }
    }
}
