using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using MyFirstAspNetCoreApplication.Filters;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyFirstAspNetCoreApplication.Controllers
{
    [AddHeaderActionFilter] //Слагаме филтъра тук като атрибут на класа и така го инстанцираме локално.
    public class InfoController : Controller
    {
        private readonly ILogger<InfoController> logger;
        private readonly IMemoryCache memoryCache;
        private readonly IDistributedCache distributedCache;

        public InfoController(ILogger<InfoController> logger, IMemoryCache memoryCache, IDistributedCache distributedCache)
        {
            this.logger = logger; //Логване означава изписване на съобщения. Може да са информационни или за грешки. С ILogger можем да изписваме съобщения (логове).

            this.memoryCache = memoryCache;
            this.distributedCache = distributedCache;
        }

        public IActionResult Time()
        {
            logger.LogInformation(12345, "User asked for the time"); // Логваме (изписваме) информация. 12345 - EventId или номер на грешката или съобщението.

            if (!memoryCache.TryGetValue<DateTime>("Data", out var casheTime))
            {
                casheTime = GetData();
                memoryCache.Set("Data", casheTime, TimeSpan.FromSeconds(20)); // Relative expiration

                memoryCache.Set("Data", casheTime, new DateTime(2021, 01, 5)); // Absolute expiration

                memoryCache.Set("Data", casheTime, 
                    new MemoryCacheEntryOptions 
                    { 
                        SlidingExpiration = new TimeSpan(0, 0, 5)
                    }); //Sliding еxpiration - ако дойде заявка към записа в кеша в рамките на 5 секунди в случая, живота му се удължава с още 5 секунди. Ако нищо не дойде като заявка в рамките на зададеното време, кеша се изчиства.
            }

            //"Data" - име на нашия кеш запис.
            // <DateTime> - искам информацията, като успееш да я прочетеш, да ми я конвертираш към DateTime.
            // TimeSpan.FromSeconds(20) - да стои 20 секунди в кеша и после се затрива. Ако не му се укаже време, стои докато не се затвори приложението. 
            //TimeSpan.FromSeconds(20) е Relative expiration. Има и Absolute expiration - указва му се на коя дата и в колко часа спира да е валиден записа в кеша.

            //Другия тип кеш е Distributed Cashe. При него кеша се записва в базата данни като таблица. За да се ползва трябва да се инсталира Microsoft.Extensions.Caching.SqlServer пакета и да се направи настройка в Startup -> ConfigureServices метода. След това през Power shell конзолата трябва с 2 команди да се направи таблицата в която да се записва кеша;
            //dotnet tool install --global dotnet-sql-cache
            //dotnet sql-cache create "Data Source=.;Initial Catalog=db;Integrated Security=True;" dbo TestCache

            return Content(
                DateTime.Now.ToLongTimeString() + " -- Cache: " + casheTime);
        }

        private DateTime GetData()
        {
            Thread.Sleep(5000); //Изкуствено забавяне от 5 секунди.
            return DateTime.Now;
        }

        //Филтъра може да се прилага и само върху конкретен екшън.
        public async Task<IActionResult> Date()
        {
            logger.LogInformation(12346, "User asked for the date"); // Логовете се показват в Output таба, когато пускаме приложението през ISS Express. Ако пуснеме приложението през Kestrel сървър (през конзолата), съобщенията (логовете) излизат на конзолата.

            //Distributed cache usage.
            var dataAsString = await distributedCache
                .GetStringAsync("DateTimeInfo");

            DateTime data;
            
            if (dataAsString == null)
            {
                data = GetData();
                await distributedCache.SetStringAsync("DateTimeInfo", JsonConvert.SerializeObject(data),
                    new DistributedCacheEntryOptions 
                    {
                        SlidingExpiration = new TimeSpan(0, 0, 10)
                    }); 
            }
            else
            {
                data = JsonConvert.DeserializeObject<DateTime>(dataAsString);
            }

            return Content(data.ToString());
        }
    }
}
