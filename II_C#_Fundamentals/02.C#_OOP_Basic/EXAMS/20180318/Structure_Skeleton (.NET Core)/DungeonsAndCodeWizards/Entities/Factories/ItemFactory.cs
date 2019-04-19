namespace DungeonsAndCodeWizards.Entities.Factories
{
    using Items;
    using System;

    public class ItemFactory
    {
        public Item CreateItem(string itemType)
        {
            switch (itemType)
            {
                case "ArmorRepairKit":
                    return new ArmorRepairKit();
                case "HealthPotion":
                    return new HealthPotion();
                case "PoisonPotion":
                    return new PoisonPotion();
                default:
                    throw new ArgumentException($"Invalid item \"{itemType}\"!");
            }
        }
    }
}
