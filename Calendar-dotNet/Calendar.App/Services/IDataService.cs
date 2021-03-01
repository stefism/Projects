using Calendar.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calendar.App.Services
{
    public interface IDataService
    {
        Task<ICollection<ReservationViewModel>> ShowAllReservations();

        Task<ICollection<UserReservationViewModel>> ShowUserReservations(string userId);

        Task ReleaseReservation(string reservationId);

        Task AddAvailableDate(DateTime date, bool IsNonWorkDay, string userId);

        Task ChangePrices(decimal workday, decimal weekends);

        bool IsNonWorkDay(DateTime date);

        Task<ICollection<ReservationViewModel>> GetReservedDates(int year, int month);
    }
}
