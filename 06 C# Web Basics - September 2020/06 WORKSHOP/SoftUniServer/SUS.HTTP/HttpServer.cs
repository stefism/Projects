using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SUS.HTTP
{
    public class HttpServer : IHttpServer
    {
        List<Route> routeTable;

        public HttpServer(List<Route> routeTable)
        {
            this.routeTable = routeTable;
        }     

        public async Task StartAsync(int port = 80)
        {
            TcpListener tcpListener =
                new TcpListener(IPAddress.Loopback, port);
            tcpListener.Start();

            while (true)
            {
                TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();
                ProcessClientAsync(tcpClient);

            }
        }

        private async Task ProcessClientAsync(TcpClient tcpClient)
        {
            try
            {
                using (NetworkStream stream = tcpClient.GetStream())
                {
                    List<byte> data = new List<byte>();

                    int position = 0;

                    byte[] buffer = new byte[HttpConstants.BufferSize];

                    while (true)
                    {
                        int count = await stream.ReadAsync(buffer, position, buffer.Length);
                        position += count;

                        if (count < buffer.Length)
                        {
                            byte[] partialBuffer = new byte[count];
                            Array.Copy(buffer, partialBuffer, count);
                            data.AddRange(partialBuffer);
                            break;
                        }
                        else
                        {
                            data.AddRange(buffer);
                        }
                    }

                    string requestAsString = Encoding.UTF8.GetString(data.ToArray());

                    HttpRequest request = new HttpRequest(requestAsString);

                    Console.WriteLine($"{request.Method} {request.Path} => {request.Headers.Count} headers.");

                    HttpResponse response;

                    var route = routeTable
                        .FirstOrDefault(x => string
                        .Compare(x.Path, request.Path, true) == 0 
                        && x.Method == request.Method); 
                    //Сравняваме без значение дали буквите са малки или големи (true). Понеже метода (IComparable) връща -1 ако е по-малко, +1 ако е по-голямо и 0 ако са равни, затова накрая му даваме 0, защото искаме да съвпадат двата стринга.

                    if (route != null)
                    {                       
                        response = route.Action(request);
                    }
                    else
                    {
                        response = new HttpResponse("text/html", new byte[0], HttpStatusCode.NotFound);
                    }

                    response.Cookies
                        .Add(new ResponceCookie("sid", Guid.NewGuid()
                        .ToString())
                        {
                            HttpOnly = true,
                            MaxAge = 60 * 24 * 60 * 60
                        });

                    response.Headers
                        .Add(new Header("Server", "SUS Server 1.0"));

                    var responseHeaderBytes = Encoding.UTF8.GetBytes(response.ToString());

                    await stream.WriteAsync(responseHeaderBytes, 0, responseHeaderBytes.Length);
                    await stream.WriteAsync(response.Body, 0, response.Body.Length);
                }

                tcpClient.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
