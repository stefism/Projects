using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Core
{
    public class Engine
    {
        private StorageMaster storageMaster;

        public Engine()
        {
            storageMaster = new StorageMaster();
        }
        public void Run()
        {
            string result = string.Empty;

            while (true)
            {
                try
                {
                    string[] input = Console.ReadLine().Split();

                if (input[0] == "END")
                {
                    result = storageMaster.GetSummary();

                    Console.WriteLine(result);

                    break;
                }

                string command = input[0];

                switch (command)
                {
                    case "AddProduct":
                        string type = input[1];
                        double price = double.Parse(input[2]);

                        result = storageMaster.AddProduct(type, price);
                        break;

                    case "RegisterStorage":
                        type = input[1];
                        string name = input[2];

                        result = storageMaster.RegisterStorage(type, name);
                        break;

                    case "SelectVehicle":
                        string storageName = input[1];
                        int garageSlot = int.Parse(input[2]);

                        result = storageMaster.SelectVehicle(storageName, garageSlot);

                        break;

                    case "LoadVehicle":
                        string[] products = input.Skip(1).ToArray();

                        result = storageMaster.LoadVehicle(products);
                        break;

                    case "SendVehicleTo":
                        string sourceName = input[1];
                        int sourceGarageSlot = int.Parse(input[2]);
                        string destinationName = input[3];

                        result = storageMaster.SendVehicleTo
                            (sourceName, sourceGarageSlot, destinationName);
                        break;

                    case "UnloadVehicle":
                        storageName = input[1];
                        garageSlot = int.Parse(input[2]);

                        result = storageMaster.UnloadVehicle(storageName, garageSlot);
                        break;

                    case "GetStorageStatus":
                        storageName = input[1];

                        result = storageMaster.GetStorageStatus(storageName);
                        break;
                }

                Console.WriteLine(result);
            }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                // Когато искаме програмата да продължи до ЕНД и да хваща грешките, трябва трай кеча да бъде вътре в while цикъла, а не извън него !!!
                // Трябва трай кеча да е във while цикъла, а не while цикъла да е във трай кеча свинио!!!
            }
        }
    }
}

