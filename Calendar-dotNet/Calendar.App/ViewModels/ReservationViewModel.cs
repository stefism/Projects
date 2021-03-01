using System;

namespace Calendar.App.ViewModels
{
    public class ReservationViewModel
    {
        public string ReservationDateId { get; set; }

        public string Username { get; set; }

        public DateTime? ReservedDate { get; set; }

        public string Price { get; set; }
    }
}
