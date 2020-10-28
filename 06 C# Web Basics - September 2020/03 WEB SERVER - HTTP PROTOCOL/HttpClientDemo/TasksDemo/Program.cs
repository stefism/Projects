using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace TasksDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            //HttpClient httpClient = new HttpClient();

            for (int i = 1; i <= 100; i++)
            {
                var task = Task.Run(async () => 
                {
                    HttpClient httpClient = new HttpClient();
                    string url = $"https://vicove.com/vic-{i}";

                    HttpResponseMessage httpResponse = await httpClient
                        .GetAsync(url);
                    string vic = await httpResponse.Content
                        .ReadAsStringAsync();
                    //string vic = httpResponse.Content
                    //    .ReadAsStringAsync().GetAwaiter().GetResult();
                    Console.WriteLine(vic.Length);
                    //Console.WriteLine(new string('*', 70));
                });

                // async - този метод, който седи вътре, мога да го разделя на под задачи. Това означава async. Метод с няколко ясно дефинирани задачи. После, нещо когато е отделна задача, отпред му се слага await и това означава - тук започва отделната задача.                
            }

            Console.WriteLine(sw.Elapsed);
            Console.ReadLine();
        }

        //Когато искаме даден метод да представлява отделно парче работа, правим метода async и той да връща Task;
        static async Task DownloadAsync() //Това е еквивалентно на void метода. Това автоматично си става на метод, който връща Task.
        {
            HttpClient http = new HttpClient();
            HttpResponseMessage response = await http.GetAsync(""); //Когато това е готово, тогава продължи с кода надолу.
            await response.Content.ReadAsStringAsync();
            await File.WriteAllTextAsync("sample path", "sample content");
        }
        //Тези неща са приложими само в ситуации в които имаме външни ресурси и ги чакаме да се обработят. Когато имаме 100% CPU не е приложимо. 
        //Разлика между многонишково и асинхронно програмиране. При многонишковото си правим много нишки. При асинхронното, на една нишка могат да работят много задачи.
    }
}
