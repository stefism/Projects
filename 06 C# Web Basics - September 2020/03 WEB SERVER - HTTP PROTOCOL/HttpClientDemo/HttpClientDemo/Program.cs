using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace HttpClientDemo
{
    class Program
    {
        static Dictionary<string, int> SessionStorage 
            = new Dictionary<string, int>();

        const string NewLine = "\r\n"; //Единствената правилна последователност за нов ред в http протокола.
        static async Task Main(string[] args) //Respons
        {            
            TcpListener tcpListener = 
                new TcpListener(IPAddress.Loopback, 12345);
            tcpListener.Start();

            while (true)
            {
                TcpClient client = tcpListener.AcceptTcpClient();
                ProcessClientAsync(client);
            }
            
            //await ReadData();
        }

        public static async Task ProcessClientAsync(TcpClient client)
        {
            using (NetworkStream stream = client.GetStream())
            {
                byte[] buffer = new byte[1000000];
                int lenght = await stream.ReadAsync(buffer, 0, buffer.Length);

                string requestString =
                    Encoding.UTF8.GetString(buffer, 0, lenght);
                Console.WriteLine(requestString);

                //Thread.Sleep(10000);

                //Session Demo
                string sid = Guid.NewGuid().ToString();
                               
                Match cookieWithSessionIdMatch = 
                    Regex.Match(requestString, @"sid=[^\n]*\r\n");
                
                if (cookieWithSessionIdMatch.Success)
                {
                    sid = cookieWithSessionIdMatch.Value.Substring(4);
                }

                if (!SessionStorage.ContainsKey(sid))
                {
                    SessionStorage.Add(sid, 0);
                }

                SessionStorage[sid]++;

                //^

                bool sessionSet = false;

                if (requestString.Contains("sid="))
                {
                    sessionSet = true;
                } 

                string html = "<h1>Мараба мили, скъпи деца :D</h1>"
                    + NewLine
                    + $"<h4>Това е сървъра на Стефчо за {SessionStorage[sid]} път.</h4>"
                    + NewLine
                    + $"<p> Датата в момента е: <strong>{DateTime.Now}</strong>.</p>"
                    + NewLine
                    + "<form method=post><input name=username /><input name=password /><input type=submit /></form>";

                string response =
                    "HTTP/1.1 200 OK" + NewLine
                    //+ "HTTP/1.1 307 Redirect" + NewLine
                    //+ "Location: https://www.google.bg" + NewLine
                    + "Server: StefanServer 2020" + NewLine
                    + "Content-Type: text/html; charset=utf-8"
                    //+"Content-Disposition: attachment; filename=stefan.txt" //Кара браузъра да запише това, което му се подава във файл. Тогава горе Content-Type: text/plain трябва да се напише.
                    + NewLine
                    + "X-Server-Version: 1.0" + NewLine 
                    //+ (!sessionSet ? ("Set-Cookie: sid =129yyS08" + NewLine) : string.Empty)
                    //Когато си пишем собствен текст в рекюеста или респонса е прието отпред да се слага "Х".
                    + $"Set-Cookie: sid ={sid}; HttpOnly; Expires=" + DateTime.UtcNow.AddDays(3).ToString("R") 
                    + NewLine
                    + "Content-Lenght: " + html.Length * 2
                    + NewLine + NewLine + html + NewLine;

                //HttpOnly - казва се за да не може JavaScript да има достъп до бисквитките!
                //SameSite - когато сайта има достъп до друг сайт, да не се пращат към другия сайт бисквитките.
                //Secure - изпраща бисквитката само ако протокола е https.

                byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                await stream.WriteAsync(responseBytes);

                Console.WriteLine(new string('=', 70));
            }
        }

        public static async Task ReadData() //Request
        {
            string url = "https://softuni.bg/trainings/3164/csharp-web-basics-september-2020/internal#lesson-18198";
            HttpClient httpClient = new HttpClient();

            //httpClient.DefaultRequestHeaders.Add("X-Client-Version", "1.0");
            //Можеме да правим собствени request хедъри. Първо е ключа, после стойността.

            var response = await httpClient.GetAsync(url);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(string.Join(Environment.NewLine, response.Headers.Select(x => x.Key + ": " + x.Value.First())));

            //string html = await httpClient.GetStringAsync(url);
            //Console.WriteLine(html);
        }
    }
}
