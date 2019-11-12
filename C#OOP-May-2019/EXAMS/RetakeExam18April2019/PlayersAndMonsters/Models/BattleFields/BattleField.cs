using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Cards;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        private const int BONUS_HEALTH = 40;
        private const int BONUS_DAMAGE_POINTS = 30;
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            //CheckIfOneOfPlayersDead(attackPlayer, enemyPlayer);

            if (attackPlayer is Beginner)
            {
                attackPlayer.Health += BONUS_HEALTH;

                foreach (var card in attackPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += BONUS_DAMAGE_POINTS;
                }
            }

            if (enemyPlayer is Beginner)
            {
                enemyPlayer.Health += BONUS_HEALTH;

                foreach (var card in enemyPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += BONUS_DAMAGE_POINTS;
                }
            }

            int attackPlayerCardHealthSum = attackPlayer.CardRepository.Cards
                .Select(x => x.HealthPoints).Sum();
            int enemyPlayerCardHealthSum = enemyPlayer.CardRepository.Cards
                .Select(x => x.HealthPoints).Sum();

            attackPlayer.Health += attackPlayerCardHealthSum;
            enemyPlayer.Health += enemyPlayerCardHealthSum;

            int attackPlayerCardDamageSum = attackPlayer.CardRepository.Cards
                .Select(x => x.DamagePoints).Sum();
            int enemyPlayerCardDamageSum = enemyPlayer.CardRepository.Cards
                .Select(x => x.DamagePoints).Sum();

            while (attackPlayer.IsDead != true && enemyPlayer.IsDead != true)
            {
                enemyPlayer.TakeDamage(attackPlayerCardDamageSum);

                //CheckIfOneOfPlayersDead(attackPlayer, enemyPlayer);

                attackPlayer.TakeDamage(enemyPlayerCardDamageSum);
            }

            //CheckIfOneOfPlayersDead(attackPlayer, enemyPlayer);
        }

        //private static void CheckIfOneOfPlayersDead(IPlayer attackPlayer, IPlayer enemyPlayer)
        //{
        //    if (attackPlayer.IsDead == true || enemyPlayer.IsDead == true)
        //    {
        //        throw new ArgumentException("Player is dead!");
        //    }
        //}
    }
}
