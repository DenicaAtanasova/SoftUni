namespace DungeonsAndCodeWizards.Entities.Characters
{
    using Bags;
    using Contracts;
    using Enums;
    using System;

    public class Warrior : Character, IAttackable
    {
        public Warrior(string name, Faction faction) : base(name, health : 100, armor : 50, abilityPoints : 40, bag : new Satchel(), faction : faction)
        {
        }

        public void Attack(Character character)
        {
            this.CheckIfAlive();
            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            if (character == this)
            {
                throw new InvalidOperationException("Cannot attack self!");
            }

            if(this.Faction == character.Faction)
            {
                throw new ArgumentException($"Friendly fire! Both characters are from {this.Faction} faction!");
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}