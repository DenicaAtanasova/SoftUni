namespace PlayersAndMonsters.Core.Factories
{
    using Factories.Contracts;
    using Models.Cards;
    using Models.Cards.Contracts;

    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            switch (type)
            {
                case "Trap":
                    return new TrapCard(name);
                case "Magic":
                    return new MagicCard(name);
                default:
                    return null;
            }
        }
    }
}
