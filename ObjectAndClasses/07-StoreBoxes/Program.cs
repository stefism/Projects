using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_StoreBoxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Item> items = new List<Item>();
            List<Boxes> boxes = new List<Boxes>();

            while (true)
            {
                string[] data = Console.ReadLine().Split();

                if (data[0] == "end")
                {
                    break;
                }

                long serialNumber = long.Parse(data[0]);
                string itemName = data[1];
                int itemQuantity = int.Parse(data[2]);
                double itemPrice = double.Parse(data[3]);

                Item currentItem = new Item();
                Boxes currentBox = new Boxes();

                currentBox.SerialNumber = serialNumber;
                currentItem.ItemName = itemName;
                currentBox.ItemQuantity = itemQuantity;
                currentItem.Price = itemPrice;

                currentBox.PriceForBox = itemQuantity * itemPrice;

                items.Add(currentItem);
                boxes.Add(currentBox);

            }

            List<FInalItemsAndPrices> finalList = new List<FInalItemsAndPrices>();
            

            //FInalItemsAndPrices[] finalList = new FInalItemsAndPrices[boxes.Count];

            for (int i = 0; i < boxes.Count; i++)
            {
                FInalItemsAndPrices finalListElements = new FInalItemsAndPrices();

                finalListElements.serialNumber = boxes[i].SerialNumber;
                finalListElements.ItemName = items[i].ItemName;
                finalListElements.ItemPrice = items[i].Price;
                finalListElements.ItemQuantity = boxes[i].ItemQuantity;
                finalListElements.BoxPrice = boxes[i].PriceForBox;

                finalList.Add(finalListElements);
            }

            List<FInalItemsAndPrices> orderedList = finalList.OrderByDescending(x => x.BoxPrice).ToList();

            foreach (var item in orderedList)
            {
                Console.WriteLine(item.serialNumber);
                Console.WriteLine($"-- {item.ItemName} - ${item.ItemPrice:F2}: {item.ItemQuantity}");
                Console.WriteLine($"-- ${item.BoxPrice:F2}");
            }
        }
    }

    class Item
    {
        public string ItemName;
        public double Price;
    }

    class Boxes
    {
        public long SerialNumber;
        public Item Item;
        public int ItemQuantity;
        public double PriceForBox;
    }

    class FInalItemsAndPrices
    {
        public long serialNumber;
        public string ItemName;
        public double ItemPrice;
        public int ItemQuantity;
        public double BoxPrice;
    }
}
