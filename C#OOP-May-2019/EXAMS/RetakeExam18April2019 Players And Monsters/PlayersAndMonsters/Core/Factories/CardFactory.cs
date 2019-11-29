using System;
using System.Collections.Generic;
using System.Text;
using PlayersAndMonsters.Models.Cards.Contracts;
using System.Reflection;
using System.Linq;

namespace PlayersAndMonsters.Core.Factories.Contracts
{
    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            Type cardType = Assembly.GetCallingAssembly().GetTypes()
                .FirstOrDefault(c => c.Name == type + "Card");

            ICard card = (ICard)Activator.CreateInstance(cardType, name);

            return card;
        }
    }
}
