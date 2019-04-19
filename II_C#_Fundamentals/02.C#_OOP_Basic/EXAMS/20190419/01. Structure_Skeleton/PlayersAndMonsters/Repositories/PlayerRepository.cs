namespace PlayersAndMonsters.Repositories
{
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PlayerRepository : IPlayerRepository
    {
        private readonly List<IPlayer> players;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }

        public int Count => this.Players.Count;

        public IReadOnlyCollection<IPlayer> Players => this.players.AsReadOnly();

        public void Add(IPlayer player)
        {
            this.CheckIfPlayerIsNull(player);

            if (this.Players.Any(p => p.Username == player.Username))
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }

            this.players.Add(player);
        }

        public IPlayer Find(string username)
        {
            var player = this.Players.FirstOrDefault(p => p.Username == username);
            this.CheckIfPlayerIsNull(player);

            return player;
        }

        public bool Remove(IPlayer player)
        {
            this.CheckIfPlayerIsNull(player);
            
            return this.players.Remove(player);
        }

        private void CheckIfPlayerIsNull(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }
        }
    }
}
