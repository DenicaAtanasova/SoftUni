namespace HAD.Entities.Heroes
{
    public class Wizard : BaseHero
    {
        private const int BaseStrength = 25;
        private const int BaseAgility = 25;
        private const int BaseIntelligence = 100;
        private const int BaseHitPoints = 100;
        private const int BaseDamage = 250;

        public Wizard(string name)
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
