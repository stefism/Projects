using System;

namespace Calendar.App.ViewModels
{
    public class UserReservationViewModel
    {
        public string ReservationDateId { get; set; }

        public DateTime? ReservedDate { get; set; }

        public string Price { get; set; }
    }
}
