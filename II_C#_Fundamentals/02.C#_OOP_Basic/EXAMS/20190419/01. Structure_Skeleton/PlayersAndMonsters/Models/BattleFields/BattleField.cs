namespace PlayersAndMonsters.Models.BattleFields
{
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using System;
    using System.Linq;

    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            this.CheckIfDead(attackPlayer);
            this.CheckIfDead(enemyPlayer);

            GetBeginnerBonus(attackPlayer);
            GetBeginnerBonus(enemyPlayer);

            GetBonusFromDeck(attackPlayer);
            GetBonusFromDeck(enemyPlayer);

            while (!attackPlayer.IsDead && !enemyPlayer.IsDead)
            {
                enemyPlayer.TakeDamage(attackPlayer.CardRepository.Cards.Sum(c => c.DamagePoints));

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                attackPlayer.TakeDamage(enemyPlayer.CardRepository.Cards.Sum(c => c.DamagePoints));
            }
        }

        private void CheckIfDead(IPlayer player)
        {
            if (player.IsDead)
                throw new ArgumentException("Player is dead!");
        }

        private void GetBeginnerBonus(IPlayer player)
        {
            if (player.GetType().Name == "Beginner")
            {
                player.Health += 40;
                
                foreach (var card in player.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
        }

        private void GetBonusFromDeck(IPlayer player)
        {
            var bonus = player.CardRepository.Cards.Sum(c => c.HealthPoints);
            player.Health += bonus;
        }
    }
}