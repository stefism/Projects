using Microsoft.EntityFrameworkCore;
using RealEstates.Data;
using RealEstates.Services;
using RealEstates.Services.Contracts;
using System;

namespace RealEstates.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new RealEstateDbContext();
            db.Database.Migrate();

            IPropertiesService propertiesService = new PropertiesService(db); // Създай нов клас "клас който се занимава с бизнес логиката на имотите (блик)"
            IDistrictService districtService = new DistrictService(db);

            //propertiesService.Create("Свобода", 100, 2019, 210000, "3-стаен", "Керемида", 20, 20); // блик.създайИмот() се едно ако беше всичко на български и ако ние бехме измислили си шарпа :D

            //GetTopDistrictsByAveragePrice(districtService);

            SearchByPriceRange(propertiesService);
        }

        private static void SearchByPriceRange(IPropertiesService propertiesService)
        {
            Console.Write("Минимална цена на имота: ");
            int minPrice = int.Parse(Console.ReadLine());

            Console.Write("Максимална цена на имота: ");
            int maxPrice = int.Parse(Console.ReadLine());

            var properties = propertiesService.SearchByPrice(minPrice, maxPrice);

            foreach (var property in properties)
            {
                Console.WriteLine(@$"Цена: {property.Price} => Размер: {property.Size} => Квартал: {property.District} =>  Етаж: {property.Floor}");
            }
        }

        private static void GetTopDistrictsByAveragePrice(IDistrictService districtService)
        {
            var districts = districtService.GetTopDistrictsByAveragePrice(12);

            foreach (var district in districts)
            {
                Console.WriteLine($"Квартал: {district.Name} => Ценови диапазон: от {district.MinPrice} до {district.MaxPrice} => Брой имоти в квартала: {district.PropertiesCount}. Средна цена: {district.AveragePrice:F2}");
            }
        }
    }
}
