namespace DungeonsAndCodeWizards.Entities.Items
{
    using Characters;
    using System;

    public class PoisonPotion : Item
    {
        private const int DefaultWeight = 5;

        private const int DecreaseHealthPoints = 20;

        public PoisonPotion() : base(DefaultWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health = Math.Max(0, character.Health - DecreaseHealthPoints);

            if (character.Health == 0)
            {
                character.IsAlive = false;
            }
        }
    }
}
