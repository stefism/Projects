using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayersAndMonsters.Models.Cards.Contracts;

namespace PlayersAndMonsters.Repositories.Contracts
{
    public class CardRepository : ICardRepository
    {
        private readonly List<ICard> cards;

        public CardRepository()
        {
            cards = new List<ICard>();
        }
        
        public int Count => cards.Count;

        public IReadOnlyCollection<ICard> Cards
        {
            get
            {
                return cards.AsReadOnly();
            }
        }

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }

            if (cards.Any(c => c.Name == card.Name))
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }

            cards.Add(card);
        }

        public ICard Find(string name)
        {
            ICard card = cards.FirstOrDefault(c => c.Name == name);

            return card;
        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }

            cards.Remove(card);
            return true;
        }
    }
}
