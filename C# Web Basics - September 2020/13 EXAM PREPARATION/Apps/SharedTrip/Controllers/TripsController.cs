using SharedTrip.Services;
using SharedTrip.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripService tripService;

        public TripsController(ITripService tripService)
        {
            this.tripService = tripService;
        }

        public HttpResponse All()
        {
            var viewModel = tripService.ShowTrips();

            return View(viewModel);
        }

        public HttpResponse Add()
        {
            return View();
        }

        [HttpPost]
        public HttpResponse Add(AddTripViewModel model)
        {
            if (string.IsNullOrEmpty(model.StartPoint))
            {
                return Error("Start point is required field. Please enter the start point.");
            }

            if (string.IsNullOrEmpty(model.EndPoint))
            {
                return Error("End point is required field. Please enter the end point.");
            }

            //if (new DateTimeFormat("dd.MM.yyyy HH:mm").ToString() != model.DepartureTime.ToString())
            //{
            //    return Error("Date/Time should be in format dd.MM.yyyy HH:mm");
            //}

            if (model.Seats < 2 || model.Seats > 6)
            {
                return Error("Invalid seat number. Seat must be between 2 and 6.");
            }

            if (string.IsNullOrEmpty(model.Description) || model.Description.Length > 80)
            {
                return Error("Description should be between 1 and 80 characters.");
            }

            tripService.AddTrip(model);

            return Redirect("/Trips/All");
        }

        public HttpResponse Details(string tripId)
        {
            var viewModel = tripService.ShowTripDetails(tripId);

            return View(viewModel);
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (tripService.IsUserTripExist(tripId, GetUserId()))
            {
                return Redirect("/Trips/All");
            }

            tripService.AddUserToTrip(tripId, GetUserId());

            return Redirect("/Trips/All");
        }
    }
}
