using SharedTrip.ViewModels;
using System.Collections.Generic;

namespace SharedTrip.Services
{
    public interface ITripService
    {
        void AddTrip(AddTripInputModel model);

        ICollection<AllTripsViewModel> ShowTrips();

        TripDetailsViewModel ShowTripDetails(string tripId);

        void AddUserToTrip(string tripId, string userId);

        bool IsUserTripExist(string tripId, string userId);
    }
}
