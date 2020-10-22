using System;

namespace SharedTrip.ViewModels
{
    public class AddTripInputModel
    {
        public string StartPoint { get; set; }

        public string EndPoint { get; set; }

        public string DepartureTime { get; set; }

        public string ImagePath { get; set; }

        public ushort Seats { get; set; }

        public string Description { get; set; }
    }
}
