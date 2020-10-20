using SharedTrip.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Services
{
    public interface ITripService
    {
        void AddTrip(AddTripViewModel model);

        ICollection<AllTripsViewModel> ShowTrips();

        TripDetailsViewModel ShowTripDetails(string tripId);

        void AddUserToTrip(string tripId, string userId);

        bool IsUserTripExist(string tripId, string userId);
    }
}
