using CarDealer.Data;
using System.IO;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new CarDealerContext();
            string suppliers = File.ReadAllText("../../../Datasets/suppliers.xml");

            string q09 = ImportSuppliers(db, suppliers);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        //Query 09. Import Suppliers
        {

        }
    }
}