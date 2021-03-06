﻿using SharedTrip.Services;
using SharedTrip.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Globalization;

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
            if (!IsUserSignedIn())
            {
                return Redirect("/Users/Login");
            }

            var viewModel = tripService.ShowTrips();

            return View(viewModel);
        }

        public HttpResponse Add()
        {
            if (!IsUserSignedIn())
            {
                return Redirect("/Users/Login");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Add(AddTripInputModel model)
        {
            if (string.IsNullOrEmpty(model.StartPoint))
            {
                return Error("Start point is required field. Please enter the start point.");
            }

            if (string.IsNullOrEmpty(model.EndPoint))
            {
                return Error("End point is required field. Please enter the end point.");
            }

            if (!DateTime.TryParseExact(model.DepartureTime, 
                "dd.MM.yyyy HH:mm", 
                CultureInfo.InvariantCulture, 
                DateTimeStyles.None, out _))
            {
                return Error("Invalid date/time format. Please use ''dd.MM.yyyy HH:mm''");
            }

            if (!Uri.TryCreate(model.ImagePath, UriKind.Absolute, out _))
            {
                return Error("Image Url is not valid. Please enter valid Url.");
            }

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
            if (!IsUserSignedIn())
            {
                return Redirect("/Users/Login");
            }

            var viewModel = tripService.ShowTripDetails(tripId);

            return View(viewModel);
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!IsUserSignedIn())
            {
                return Redirect("/Users/Login");
            }

            if (tripService.IsUserTripExist(tripId, GetUserId()))
            {
                return Redirect($"/Trips/Details?tripId={tripId}"); // /Trips/Details - not work
            }

            tripService.AddUserToTrip(tripId, GetUserId());

            return Redirect("/Trips/All");
        }
    }
}
