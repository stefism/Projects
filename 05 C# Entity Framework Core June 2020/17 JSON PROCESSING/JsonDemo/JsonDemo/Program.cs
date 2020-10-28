using CsvHelper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Xml;

namespace JsonDemo
{
    class Car // CSV demo
    {
        public int Year { get; set; }

        public string Make { get; set; }

        public string  Model { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }

    class WeatherForecast // Json demo
    {
        [JsonProperty("CurrentDate")] // Сменя името на пропертито в жейсъна.
        public DateTime Date { get; set; } = DateTime.Now;

        public int TemperatureC { get; set; } = 30;

        public string Summary { get; set; } = "Hot summer day";

        [JsonIgnore] // Ако искаме да не се чете от жейсъна.
        public int Map { get; set; } = 123;
    }

    class Program
    {
        static void Main(string[] args)
        {
            //SystemTextJson();

            var contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }; // Optional

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ContractResolver = contractResolver
            }; // Optional

            var weather = new WeatherForecast();
            string json = JsonConvert
                .SerializeObject(weather, Newtonsoft.Json.Formatting.Indented); //Newtonsoft.Json. => Само когато се бърка с друг юзинг му се слагат изрично отпреде. Иначе нема нужда.

            //File.WriteAllText("weather.json", json);

            string jsonRead = File.ReadAllText("weather.json");

            //Linq to Json
            JObject jObject = JObject.Parse(jsonRead);
            JToken summary = jObject["Summary"];
            Console.WriteLine(summary); // => Hot summer day

            var weatherFromJson = JsonConvert.DeserializeObject<WeatherForecast>(jsonRead);

            //Console.WriteLine(json);

            // XmlToJson();

            //CsvToClass
            using (CsvReader reader = new CsvReader
                (new StreamReader("CarCsv.csv"), CultureInfo.InvariantCulture))
            {
                var readedCars = reader.GetRecords<Car>().ToList();
            }

            //ClassToCsv
            var cars = new List<Car>
            {
                new Car {Year = 2020, Model = "dfsdfds", Make = "dfgdfg", Price = 452, Description = "wewtewt"},
                new Car {Year = 2020, Model = "dfsdfds", Make = "dfgdfg", Price = 452, Description = "wewtewt"}
            };

            using(CsvWriter writer = new CsvWriter
                (new StreamWriter("Car2.csv"), CultureInfo.InvariantCulture))
            {
                writer.WriteRecords(cars);
            }
        }

        private static void XmlToJson()
        {
            // XML to Json
            string xml = @"<?xml version='1.0' standalone='no'?>
                                        <root>
                                        <person id='1'>
                                        <name>Alan</name>
                                        <url>www.google.com</url>
                                        </person>
                                        <person id='2'>
                                        <name>Louis</name>
                                        <url>www.yahoo.com</url>
                                        </person>
                                        </root>";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            var jsonText = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented);
            Console.WriteLine(jsonText);
        }

        private static void SystemTextJson()
        {
            var weather = new WeatherForecast();
            string json = System.Text.Json.JsonSerializer.Serialize(weather,
                new JsonSerializerOptions { WriteIndented = true });

            //File.WriteAllText("weather.json", json);
            //Console.WriteLine(json);

            string jsonRead = File.ReadAllText("weather.json");

            var weatherFromJson = System.Text.Json.JsonSerializer
                .Deserialize<WeatherForecast>(jsonRead);           
        }
    }
}
