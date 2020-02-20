using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace JSONDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputJson = File.ReadAllText("./../../../products.json");

            var products = JsonConvert
                .DeserializeObject<ProductDto[]>(inputJson);

            var againJson = JsonConvert.SerializeObject(products);
        }
    }
}
