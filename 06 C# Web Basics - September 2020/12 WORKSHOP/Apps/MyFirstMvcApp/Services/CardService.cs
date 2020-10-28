using BattleCards.Data;
using BattleCards.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace BattleCards.Services
{
    public class CardService : ICardService
    {
        private readonly ApplicationDbContext db;

        public CardService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public int AddCard(AddCardInputModel model)
        {
            var card = new Card
            {               
                Attack = model.Attack,
                Health = model.Health,
                Description = model.Description,
                Name = model.Name,
                ImageUrl = model.Image,
                Keyword = model.Keyword,
            };

            db.Cards.Add(card);
            db.SaveChanges();

            return card.Id;
        }

        public void AddCardToCollection(int cardId, string userId)
        {
            if (db.UserCards.Any(x => x.UserId == userId
            && x.CardId == cardId))
            {
                return;
            }

            var card = new UserCard
            {
                CardId = cardId,
                UserId = userId
            };

            db.UserCards.Add(card);
            db.SaveChanges();
        }

        public IEnumerable<CardViewModel> GetAll()
        {
            return db.Cards
                .Select(db => new CardViewModel
                {
                    Id = db.Id,
                    Name = db.Name,
                    Attack = db.Attack,
                    Health = db.Health,
                    ImageUrl = db.ImageUrl,
                    Type = db.Keyword,
                    Description = db.Description
                }).ToList();
        }

        public IEnumerable<CardViewModel> GetByUserId(string userId)
        {
            return db.UserCards.Where(x => x.UserId == userId)
                .Select(x => new CardViewModel
                {
                    Attack = x.Card.Attack,
                    Description = x.Card.Description,
                    Health = x.Card.Health,
                    ImageUrl = x.Card.ImageUrl,
                    Name = x.Card.Name,
                    Type = x.Card.Keyword,
                    Id = x.CardId
                }).ToList(); // AWAYS CALL ToList() AT THE END!!!
        }

        public void RemoveFromCollection(int cardId, string userId)
        {
            var card = db.UserCards.Where(x => x.CardId == cardId && x.UserId == userId).FirstOrDefault();

            if (card == null)
            {
                return;
            }

            db.UserCards.Remove(card);
            db.SaveChanges();
        }
    }
}
