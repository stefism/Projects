using System;

namespace _01AdvertisementMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phrases = new string[] { "Excellent product.",
                "Such a great product.", "I always use that product.",
                "Best product of its category.", "Exceptional product.",
                "I can’t live without this product." };

            string[] events = new string[] { "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.", "I feel great!" };

            string[] authors = new string[] { "Diana", "Petya", "Stella", "Elena",
                "Katya", "Iva", "Annie", "Eva" };

            string[] cities = new string[] { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            var random = new Random();



            int numberOfPhrases = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPhrases; i++)
            {
                int randomIndexPhrases = random.Next(0, phrases.Length);
                int randomIndexEvents = random.Next(0, events.Length);
                int randomIndexAuthors = random.Next(0, authors.Length);
                int randomIndexCities = random.Next(0, cities.Length);

                string shufflePhrases = phrases[randomIndexPhrases] + " " + events[randomIndexEvents] + " "
                     + authors[randomIndexAuthors] + " - " + cities[randomIndexCities];

                Console.WriteLine(shufflePhrases);
            }
        }
    }
}
