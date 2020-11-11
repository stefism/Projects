using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sandbox
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Автоматично пращане и попълване на данни в логин форма с Post метод.

            HttpClient httpClient = new HttpClient();
            var listOfParameters = new List<KeyValuePair<string, string>>();
            listOfParameters.Add(new 
                KeyValuePair<string, string>("Input.Email", "admin2@nikolay.it"));
            listOfParameters.Add(new
                KeyValuePair<string, string>("Input.Password", "123456"));

            var response = await httpClient.PostAsync("https://presscenter.com/Identity/Account/Login", new FormUrlEncodedContent(listOfParameters));

            //Параметрите които въвеждаме ги взимаме от съответния сайт за който искаме да пратим формата. Първо се логваме и виждаме в бодито какво се изпраща към формата. В случая се пращат горните mail и password.
            //Всички подадени бисквитки httpClient ги записва при себе си и после при следваща заявка ще ги подаде автоматично. (httpClient.GetAsync).
        }
    }
}
