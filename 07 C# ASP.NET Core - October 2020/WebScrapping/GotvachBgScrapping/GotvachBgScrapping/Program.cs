using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AngleSharp;

namespace GotvachBgScrapping
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //AngleSharp library. Менажира Dom дървото.

            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);

            await GetRecipe(context, 10);
        }

        private static async Task GetRecipe(IBrowsingContext context, int id)
        {
            var document = await context.OpenAsync("https://recepti.gotvach.bg/r-160281");

            if (document.StatusCode == HttpStatusCode.NotFound)
            {
                Console.WriteLine($"{id} not found.");
                return;
            }

            var recipeNameAndCategory = document
                .QuerySelectorAll("#recEntity > div.breadcrumb")
                .Select(x => x.TextContent).FirstOrDefault()
                .Split(" »", StringSplitOptions.RemoveEmptyEntries)
                .Reverse().ToArray();

            var categoryName = recipeNameAndCategory[1];
            Console.WriteLine(categoryName);

            var recipeName = recipeNameAndCategory[0].TrimStart();
            Console.WriteLine(recipeName);

            var instructions = document.QuerySelectorAll(".text > p");
            foreach (var item in instructions)
            {
                Console.WriteLine(item.TextContent);
            }

            var timing = document.QuerySelectorAll(".mbox > .feat.small");

            var prepTime = timing[0].TextContent
                .Replace("Приготвяне", string.Empty)
                .Replace(" мин.", string.Empty);
            Console.WriteLine(prepTime);

            var cookingTime = timing[1].TextContent
                .Replace("Готвене", string.Empty)
                .Replace(" мин.", string.Empty);
            Console.WriteLine(cookingTime);

            var portionCount = document
                .QuerySelectorAll(".mbox > .feat > span")
                .LastOrDefault();
            Console.WriteLine(portionCount.TextContent);

            var imageUrl = document
                .QuerySelector("#newsGal > div.image > img")
                .GetAttribute("src");
            Console.WriteLine(imageUrl);

            var ingredients = document.QuerySelectorAll(".products li");
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine(ingredient.TextContent);
            }

            Console.WriteLine($"{id} found.");
        }
    }
}
