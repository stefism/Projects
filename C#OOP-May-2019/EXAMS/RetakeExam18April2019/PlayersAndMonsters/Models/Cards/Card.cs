using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.Cards.Contracts;
using System;

namespace PlayersAndMonsters.Models.Cards
{
    public abstract class Card : ICard
    {
        private string name;
        private int damagePoints;
        private int healthPoints;

        protected Card(string name, int damagePoints, int healthPoints)
        {
            Name = name;
            DamagePoints = damagePoints;
            HealthPoints = healthPoints;
        }

        public string Name 
        {
            get => name;

            private set 
            {
                Validator.ThrowIfStringIsNullOrEmpty(value, ExceptionMessages
                    .CardNameCaanotBeNullOrEmpty);

                name = value;
            }
        }

        public int DamagePoints 
        {
            get => damagePoints;

            set 
            {
                Validator.ThrowIfIntegerBelowZero(value, ExceptionMessages
                    .CardDamagePointsCannotBeLessThanZero);

                damagePoints = value;
            }
        }

        public int HealthPoints 
        {
            get => healthPoints;

            private set 
            {
                Validator.ThrowIfIntegerBelowZero(value, ExceptionMessages
                    .CardHpCannotBeLessThanZero);

                healthPoints = value;
            }
        }
    }
}
