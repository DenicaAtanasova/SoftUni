namespace DungeonsAndCodeWizards.Entities.Characters
{
    using Bags;
    using Enums;
    using Items;
    using System;
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;

            this.BaseHealth = health;
            this.Health = health;

            this.BaseArmor = armor;
            this.Armor = armor;

            this.AbilityPoints = abilityPoints;
            this.Bag = bag;

            this.Faction = faction;
        }

        public bool IsAlive { get; set; } = true;

        public Bag Bag { get; }

        public string Name
        {
            get { return this.name; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                this.name = value;
            }
        }

        public double BaseHealth { get; private set; }

        public double Health
        {
            get { return this.health; }

            set
            {
                this.health = Math.Max(0, Math.Min(value, this.BaseHealth));
            }
        }

        public double BaseArmor { get;  private set; }

        public double Armor
        {
            get {return this.armor;}

            set
            {
                this.armor = Math.Max(0, Math.Min(value, this.BaseArmor));
            }
        }

        public double AbilityPoints { get; private set; }

        public Faction Faction { get; }

        protected virtual double RestHealMultiplier => (double)1 / 5;

        public void TakeDamage(double hitPoints)
        {
            this.CheckIfAlive();

            var hitpointsLeftAfterArmorDamage = Math.Max(0, hitPoints - this.Armor);
            this.Armor -= hitPoints;
            this.Health -= hitpointsLeftAfterArmorDamage;

            if (this.Health == 0)
            {
                this.IsAlive = false;
            }
        }

        public void Rest()
        {
            CheckIfAlive();

            this.Health = Math.Min(this.Health + this.BaseHealth * RestHealMultiplier, this.BaseHealth);
        }

        public void UseItem(Item item)
        {
            UseItemOn(item, this);
        }

        public void UseItemOn(Item item, Character character)
        {
            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            character.ReceiveItem(item);
        }

        public void ReceiveItem(Item item)
        {
            this.Bag.AddItem(item);
        }

        protected void CheckIfAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        public override string ToString()
        {
            const string format = "{0} - HP: {1}/{2}, AP: {3}/{4}, Status: {5}";

            var result = string.Format(format,
                this.Name,
                this.Health,
                this.BaseHealth,
                this.Armor,
                this.BaseArmor,
                this.IsAlive ? "Alive" : "Dead");

            return result;
        }
    }
}
