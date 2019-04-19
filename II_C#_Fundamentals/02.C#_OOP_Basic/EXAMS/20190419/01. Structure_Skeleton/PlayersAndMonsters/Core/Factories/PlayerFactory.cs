namespace PlayersAndMonsters.Core.Factories
{
    using Factories.Contracts;
    using Models.Players;
    using Models.Players.Contracts;
    using Repositories;

    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            switch (type)
            {
                case "Beginner":
                    return new Beginner(new CardRepository(), username);
                case "Advanced":
                    return new Advanced(new CardRepository(), username);
                default:
                    return null;
            }
        }
    }
}
