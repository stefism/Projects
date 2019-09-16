using System;

namespace LaptopShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string laptopMake = "Asus";
            string laptopModel = "Rog2356";
            double laptopDisplaySize = 15.3;
            decimal laptopPrice = 334;
            int laptopRam = 32;
            int laptopSsd = 256;

            Laptop laptop = new Laptop(laptopMake, laptopModel, laptopDisplaySize, 
                laptopPrice, laptopRam, laptopSsd);

            Shop shop = new Shop();

            shop.AddLaptop(laptop);
            Console.WriteLine(shop.count);

            shop.PrintAllLaptops(x => Console.WriteLine(x.FullInfo()));
        }
    }
}
