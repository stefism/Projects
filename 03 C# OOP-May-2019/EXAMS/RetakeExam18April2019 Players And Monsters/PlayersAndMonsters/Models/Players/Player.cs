using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        //private bool isDead;

        protected Player(ICardRepository cardRepository, string username, int health)
        {
            CardRepository = cardRepository;
            Username = username;
            Health = health;
        }

        public ICardRepository CardRepository { get; private set; }

        public string Username 
        {
            get => username;

            private set // Внимавай за сетерите! Трябва да са private там където трябва - задължително! Иначе гърми! От интерфейсите гледай за това и внимавай много!
            {
                Validator.ThrowIfStringIsNullOrEmpty(value, ExceptionMessages
                    .PlayerUserNameCannotBeNull);

                username = value;
            }
        }

        public int Health 
        {
            get => health;

            set 
            {
                //if (value <= 0)
                //{
                //    isDead = true;
                //}

                //if (value < 0)
                //{
                //    value = 0;
                //}

                Validator.ThrowIfIntegerBelowZero(value, ExceptionMessages
                    .PlayersHealthBelowZero);

                health = value;
            }
        }

        public bool IsDead => health <= 0;

        public void TakeDamage(int damagePoints)
        {
            Validator.ThrowIfIntegerBelowZero(damagePoints, ExceptionMessages
                .DamagePointsCannotBeLessThanZero);

            int newHealth = Health - damagePoints;

            if (newHealth < 0)
            {
                Health = 0;
            }
            else
            {
                Health = newHealth;
            }

            // Или! Разписано на 1 ред:
            // Health = Math.Max(Health - damagePoints, 0);
            // Ако разликата от Health - damagePoints е отрицателно число, дава нула, защото нулата е по-гоямо или в случая нулата е Max-a.

            // Ето това ^ е фитката към това да не дава онази грешка, когато не трябва!
        }

        public override string ToString()
        {
            return string.Format(ConstantMessages
                .PlayerReportInfo, Username, Health, CardRepository.Count);
        }
    }
}
