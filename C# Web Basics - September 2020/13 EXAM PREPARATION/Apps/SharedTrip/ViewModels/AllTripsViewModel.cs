using System;

namespace SharedTrip.ViewModels
{
    public class AllTripsViewModel
    {
        public string Id { get; set; }

        public string StartPoint { get; set; }

        public string EndPoint { get; set; }

        public DateTime DepartureTime { get; set; }

        public ushort Seats { get; set; }
    }
}
