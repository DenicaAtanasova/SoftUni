namespace DungeonsAndCodeWizards.Entities.Items
{
    using Characters;

    public class HealthPotion : Item
    {
        private const int DefaultWeight = 5;
        private const int IncreaseHealthPoints = 20;

        public HealthPotion() : base(DefaultWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health += IncreaseHealthPoints;
        }
    }
}
