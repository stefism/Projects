using System;

namespace SharedTrip.ViewModels
{
    public class TripDetailsViewModel
    {
        public string Id { get; set; }

        public string ImagePath { get; set; }

        public string StartPoint { get; set; }

        public string EndPoint { get; set; }

        public DateTime DepartureTime { get; set; }

        public string DepartureTimeAsLocal
            => DepartureTime.ToString("s");

        public ushort Seats { get; set; }

        public string Description { get; set; }
    }
}
