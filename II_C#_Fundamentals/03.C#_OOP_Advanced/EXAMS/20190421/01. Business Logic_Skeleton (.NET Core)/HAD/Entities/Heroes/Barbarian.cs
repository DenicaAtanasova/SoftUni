namespace HAD.Entities.Heroes
{
    //TODO check if have to be long
    public class Barbarian : BaseHero
    {
        private const int BaseStrength = 90;
        private const int BaseAgility = 25;
        private const int BaseIntelligence = 10;
        private const int BaseHitPoints = 350;
        private const int BaseDamage = 150;

        public Barbarian(string name)
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