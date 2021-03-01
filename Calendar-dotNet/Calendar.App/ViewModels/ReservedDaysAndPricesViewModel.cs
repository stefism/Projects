using System.Collections.Generic;

namespace Calendar.App.ViewModels
{
    public class ReservedDaysAndPricesViewModel
    {
        public PricesAndUserReservationsViewModel Prices { get; set; }
        public ICollection<ReservationViewModel> ReservedDays { get; set; } = new List<ReservationViewModel>();
    }
}
