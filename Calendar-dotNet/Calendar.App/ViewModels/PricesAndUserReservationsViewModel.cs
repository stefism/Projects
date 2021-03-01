using System.Collections.Generic;

namespace Calendar.App.ViewModels
{
    public class PricesAndUserReservationsViewModel
    {
        public decimal WorkDay { get; set; }

        public decimal NonWorkDay { get; set; }

        public string TotalAmount { get; set; }

        public ICollection<UserReservationViewModel> UsersReservations { get; set; }
    }
}
