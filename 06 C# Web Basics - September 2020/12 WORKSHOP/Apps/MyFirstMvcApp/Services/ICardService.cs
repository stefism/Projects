using BattleCards.ViewModels;
using System.Collections.Generic;

namespace BattleCards.Services
{
    public interface ICardService
    {
        int AddCard(AddCardInputModel inputModel);

        void RemoveFromCollection(int cardId, string userId);

        void AddCardToCollection(int cardId, string userId);

        IEnumerable<CardViewModel> GetAll();

        IEnumerable<CardViewModel> GetByUserId(string userId);
    }
}
