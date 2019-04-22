namespace HAD.Entities.Heroes
{
    public class Assassin : BaseHero
    {
        private const int BaseStrength = 25;
        private const int BaseAgility = 100;
        private const int BaseIntelligence = 15;
        private const int BaseHitPoints = 150;
        private const int BaseDamage = 300;

        public Assassin(string name)
            : base(
                name,
                BaseStrength,
                BaseAgility,
                BaseIntelligence,
                BaseHitPoints,
                BaseDamage)
        { }
    }
}
