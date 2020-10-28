using System;

namespace SharedTrip.ViewModels
{
    public class AllTripsViewModel
    {
        public string Id { get; set; }

        public string StartPoint { get; set; }

        public string EndPoint { get; set; }

        public DateTime DepartureTime { get; set; }

        //Ако имаме нужда да конвертираме DateTime в друг формат;
        public string DepartureTimeAsString => 
            DepartureTime.ToString("yyyy-MM-dddd"); //В скобите на ту стринта казваме в какъв формат искаме датата. После това проперти го ползваме във html страницата (вю-то) за визуализиране.

        public ushort Seats { get; set; }
    }
}
