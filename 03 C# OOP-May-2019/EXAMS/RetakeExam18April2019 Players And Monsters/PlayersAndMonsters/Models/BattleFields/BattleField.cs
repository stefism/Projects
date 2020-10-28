using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Linq;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        private const int BONUS_HEALTH = 40;
        private const int BONUS_DAMAGE_POINTS = 30;
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            CheckIfOneOfPlayersDead(attackPlayer, enemyPlayer);

            AddBonusToBeginnerPlayer(attackPlayer);

            AddBonusToBeginnerPlayer(enemyPlayer);

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

            while (true)
            {
                enemyPlayer.TakeDamage(attackPlayerCardDamageSum);

                if (enemyPlayer.IsDead == true)
                {
                    break;
                }

                attackPlayer.TakeDamage(enemyPlayerCardDamageSum);

                if (attackPlayer.IsDead == true)
                {
                    break;
                }
            }
        }

        private static void AddBonusToBeginnerPlayer(IPlayer player)
        {
            if (player is Beginner)
            {
                player.Health += BONUS_HEALTH;

                foreach (var card in player.CardRepository.Cards)
                {
                    card.DamagePoints += BONUS_DAMAGE_POINTS;
                }
            }
        }

        private static void CheckIfOneOfPlayersDead(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead == true || enemyPlayer.IsDead == true)
            {
                throw new ArgumentException(ExceptionMessages.DeadPlayer);
            }
        }
    }
}
