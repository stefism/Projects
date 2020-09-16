using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string NewLine = "\r\n"; //Единствената правилна последователност за нов ред в http протокола.

            TcpListener tcpListener = 
                new TcpListener(IPAddress.Loopback, 12345);
            tcpListener.Start();

            while (true)
            {
                TcpClient client = tcpListener.AcceptTcpClient();

                using (NetworkStream stream = client.GetStream())
                {
                    byte[] buffer = new byte[1000000];
                    int lenght = stream.Read(buffer, 0, buffer.Length);

                    string requestString =
                        Encoding.UTF8.GetString(buffer, 0, lenght);
                    Console.WriteLine(requestString);

                    string html = "<h1>Мараба мили, скъпи деца :D</h1>" + NewLine + "<h4>Това е сървъра на Стефчо</h4>" + NewLine + $"<p> Датата в момента е: <strong>{DateTime.Now}</strong>.</p>";

                    string response = "HTTP/1.1 200 OK" + NewLine + "Server: StefanServer 2020" + NewLine + "Content-Type: text/html; charset=utf-8" + NewLine + "Content-Lenght: " + html.Length * 2 + NewLine + NewLine + html + NewLine;

                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                    stream.Write(responseBytes);

                    Console.WriteLine(new string('=', 70));
                }                                          
            }
            
            //await ReadData();
        }

        public static async Task ReadData()
        {
            string url = "https://softuni.bg/trainings/3164/csharp-web-basics-september-2020/internal#lesson-18198";
            HttpClient httpClient = new HttpClient();

            var response = await httpClient.GetAsync(url);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(string.Join(Environment.NewLine, response.Headers.Select(x => x.Key + ": " + x.Value.First())));

            //string html = await httpClient.GetStringAsync(url);
            //Console.WriteLine(html);
        }
    }
}
