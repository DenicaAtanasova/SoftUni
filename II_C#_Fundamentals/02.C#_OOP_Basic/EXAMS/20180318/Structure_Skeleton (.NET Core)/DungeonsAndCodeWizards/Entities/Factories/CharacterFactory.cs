namespace DungeonsAndCodeWizards.Entities.Factories
{
    using Characters;
    using Characters.Enums;
    using System;

    public class CharacterFactory
    {
        public Character CreateCharacter(string factionType, string characterType, string name)
        {
            var isFactionValid = Enum.TryParse(factionType, out Faction faction);
            if (!isFactionValid)
            {
                throw new ArgumentException($"Invalid faction \"{factionType}\"!");
            }

            switch (characterType)
            {
                case "Warrior":
                    return new Warrior(name, faction);
                case "Cleric":
                    return new Cleric(name, faction);
                default:
                    throw new ArgumentException($"Invalid character type \"{characterType}\"!");
            }
        }
    }
}