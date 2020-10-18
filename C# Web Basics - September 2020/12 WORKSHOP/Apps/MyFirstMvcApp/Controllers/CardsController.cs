using BattleCards.Data;
using BattleCards.Services;
using BattleCards.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Linq;

namespace BattleCards.Controllers
{
    public class CardsController : Controller
    {       
        private readonly ICardService cardService;

        public CardsController(ICardService cardService)
        {
            
            this.cardService = cardService;
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
        public HttpResponse Add(AddCardInputModel model)
        {
            if (!IsUserSignedIn())
            {
                return Redirect("/Users/Login");
            }

            //var dbContext = new ApplicationDbContext(); The dependency inversion principle is not observed! All we need, must be filled in the constructor!

            if (string.IsNullOrEmpty(model.Name) || model.Name.Length < 5 || model.Name.Length > 15)
            {
                return Error("Name should be between 5 and 15 character long.");
            }

            if (string.IsNullOrWhiteSpace(model.Image))
            {
                return Error("The image is required.");
            }

            if (!Uri.TryCreate(model.Image, UriKind.Absolute, out _))
            {
                return Error("Image url is not valid.");
            }

            if (string.IsNullOrWhiteSpace(model.Keyword))
            {
                return Error("The Keyword is required.");
            }

            if (model.Attack < 0)
            {
                return Error("Attack must be positive number.");
            }

            if (model.Health < 0)
            {
                return Error("Health must be positive number.");
            }

            if (string.IsNullOrWhiteSpace(model.Description)
                || model.Description.Length > 200)
            {
                return Error("Description must be between 1 and 200 characters.");
            }

            var cardId = cardService.AddCard(model);

            var userId = GetUserId();
            cardService.AddCardToCollection(cardId, userId);
           
            return Redirect("/Cards/All");
        }

        public HttpResponse All()
        {
            if (!IsUserSignedIn())
            {
                return Redirect("/Users/Login");
            }

            //var db = new ApplicationDbContext(); The dependency inversion principle is not observed! All we need, must be filled in the constructor!

            var cardsViewModel = cardService.GetAll();

            return View(cardsViewModel);
        }

        public HttpResponse Collection()
        {
            if (!IsUserSignedIn())
            {
                return Redirect("/Users/Login");
            }

            var userId = GetUserId();
            var cards = cardService.GetByUserId(userId);

            return View(cards);
        }

        public HttpResponse RemoveFromCollection(int cardId)
        {
            if (!IsUserSignedIn())
            {
                return Redirect("/Users/Login");
            }

            cardService.RemoveFromCollection(cardId, GetUserId());

            return Redirect("/Cards/Collection");
        }

        public HttpResponse AddToCollection(int cardId)
        {
            if (!IsUserSignedIn())
            {
                return Redirect("/Users/Login");
            }

            cardService.AddCardToCollection(cardId, GetUserId());
            
            return Redirect("/Cards/Collection");
        }
    }
}
