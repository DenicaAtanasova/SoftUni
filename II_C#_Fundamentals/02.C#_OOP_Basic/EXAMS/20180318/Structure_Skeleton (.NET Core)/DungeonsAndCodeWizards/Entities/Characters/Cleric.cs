namespace DungeonsAndCodeWizards.Entities.Characters
{
    using System;
    using Contracts;
    using Enums;
    using Bags;

    public class Cleric : Character, IHealable
    {
        public Cleric(string name, Faction faction) : base(name, health : 50, armor : 25, abilityPoints : 40, bag : new Backpack(), faction : faction)
        {
        }

        protected override double RestHealMultiplier => 0.5;

        public void Heal(Character character)
        {
            this.CheckIfAlive();
            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            if (character.Faction != this.Faction)
            {
                throw new InvalidOperationException("Cannot heal enemy character!");
            }

            character.Health += this.AbilityPoints;
        }
    }
}
