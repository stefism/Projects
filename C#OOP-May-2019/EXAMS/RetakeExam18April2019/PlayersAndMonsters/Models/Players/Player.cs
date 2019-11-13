using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private bool isDead;

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

            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Player's username cannot be null or an empty string.");
                }

                username = value;
            }
        }

        public int Health 
        {
            get => health;

            set 
            {
                if (value <= 0)
                {
                    isDead = true;
                }

                if (value < 0)
                {
                    value = 0;
                }

                if (value < 0)
                {
                    throw new ArgumentException("Player's health bonus cannot be less than zero.");
                }

                health = value;
            }
        }

        public bool IsDead => isDead; // Евентуално тука да направим ако здравето падне до нула да превключва на true;

        public void TakeDamage(int damagePoints)
        {
            if (damagePoints < 0)
            {
                throw new ArgumentException("Damage points cannot be less than zero.");
            }

            Health -= damagePoints;
            //DeadPlayer();
        }

        //private void DeadPlayer() // Евентуално да го махна! Сетнах го в сетъра.
        //{
        //    if (Health == 0)
        //    {
        //        isDead = true;
        //    }
        //}
    }
}
