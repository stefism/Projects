using SharedTrip.Data;
using SharedTrip.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SharedTrip.Services
{
    public class TripService : ITripService
    {
        private readonly ApplicationDbContext db;

        public TripService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddTrip(AddTripViewModel model)
        {
            Trip trip = new Trip
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                DepartureTime = model.DepartureTime,
                Seats = model.Seats,
                Description = model.Description,
                ImagePath = model.ImagePath
            };

            db.Trips.Add(trip);
            db.SaveChanges();
        }

        public void AddUserToTrip(string tripId, string userId)
        {
            db.UsersTrips.Add(new UserTrip
            {
                TripId = tripId,
                UserId = userId
            });

            var trip = db.Trips.FirstOrDefault(t => t.Id == tripId);
            trip.Seats--;

            db.SaveChanges();
        }

        public bool IsUserTripExist(string tripId, string userId)
        {
            var userTrip = db.UsersTrips.FirstOrDefault(x => x.TripId == tripId && x.UserId == userId);

            if (userTrip == null)
            {
                return false;
            }

            return true;
        }

        public TripDetailsViewModel ShowTripDetails(string tripId)
        {
            var trip = db.Trips.Where(t => t.Id == tripId)
                .Select(t => new TripDetailsViewModel
                {
                    Id = t.Id,
                    ImagePath = t.ImagePath,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime,
                    Seats = t.Seats,
                    Description = t.Description
                }).FirstOrDefault();

            return trip;

        }

        public ICollection<AllTripsViewModel> ShowTrips()
        {
            return db.Trips.Select(t => new AllTripsViewModel
            {
                Id = t.Id,
                StartPoint = t.StartPoint,
                EndPoint = t.EndPoint,
                DepartureTime = t.DepartureTime,
                Seats = t.Seats
            }).ToList();
        }
    }
}
