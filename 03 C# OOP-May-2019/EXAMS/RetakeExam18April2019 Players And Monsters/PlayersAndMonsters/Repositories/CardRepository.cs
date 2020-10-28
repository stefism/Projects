using System;
using System.Collections.Generic;
using System.Linq;
using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.Cards.Contracts;

namespace PlayersAndMonsters.Repositories.Contracts
{
    public class CardRepository : ICardRepository
    {
        private IDictionary<string, ICard> cardsByName;

        //private readonly List<ICard> cards;

        public CardRepository()
        {
            cardsByName = new Dictionary<string, ICard>();

            //cards = new List<ICard>();
        }
        
        public int Count => cardsByName.Count;

        public IReadOnlyCollection<ICard> Cards 
            => cardsByName.Values.ToList();
        //{
        //    get
        //    {
        //        return cards.AsReadOnly();
        //    }
        //}

        public void Add(ICard card)
        {
            Validator.ThrowObjectCannotBeNull(card, ExceptionMessages
                .CardCannotBeNull);

            if (cardsByName.ContainsKey(card.Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages
                    .CardNameExist, card.Name));
            }

            cardsByName[card.Name] = card;
            //cards.Add(card);
        }

        public ICard Find(string name)
        {
            //ICard card = cards.FirstOrDefault(c => c.Name == name);

            //return card;

            ICard card = null;

            if (cardsByName.ContainsKey(name))
            {
                card = cardsByName[name];
            }

            return card;
        }

        public bool Remove(ICard card)
        {
            Validator.ThrowObjectCannotBeNull(card, ExceptionMessages
                .CardCannotBeNull);

            bool hasRemoved = cardsByName.Remove(card.Name);
            //cards.Remove(card);
            return hasRemoved;
        }
    }
}
