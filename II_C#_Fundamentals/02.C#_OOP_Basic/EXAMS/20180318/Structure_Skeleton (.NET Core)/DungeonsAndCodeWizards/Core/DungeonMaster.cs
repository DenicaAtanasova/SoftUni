namespace DungeonsAndCodeWizards.Core
{
    using Entities.Items;
    using Entities.Characters;
    using Entities.Factories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using DungeonsAndCodeWizards.Entities.Characters.Contracts;

    public class DungeonMaster
    {
        private readonly List<Character> party;
        private readonly Stack<Item> itemPool;

        private readonly CharacterFactory characterFactory;
        private readonly ItemFactory itemFactory;

        private int lastSurvivorRounds;

        public DungeonMaster()
        {
            this.party = new List<Character>();
            this.itemPool = new Stack<Item>();

            this.characterFactory = new CharacterFactory();
            this.itemFactory = new ItemFactory();

        }

        public string JoinParty(string[] args)
        {
            var factionType = args[0];
            var characterType = args[1];
            var name = args[2];

            var character = this.characterFactory.CreateCharacter(factionType, characterType, name);
            this.party.Add(character);

            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            var itemType = args[0];

            var item = this.itemFactory.CreateItem(itemType);
            this.itemPool.Push(item);

            return $"{itemType} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            var characterName = args[0];
            var character = this.GetCharacter(characterName);

            if (this.itemPool.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            var item = this.itemPool.Pop();
            character.ReceiveItem(item);

            return $"{characterName} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            var characterName = args[0];
            var itemName = args[1];

            var character = this.GetCharacter(characterName);

            var item = character.Bag.GetItem(itemName);
            character.UseItem(item);

            return $"{characterName} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];

            var giver = this.GetCharacter(giverName);
            var receiver = this.GetCharacter(receiverName);
            var item = giver.Bag.GetItem(itemName);

            giver.UseItemOn(item, receiver);

            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];

            var giver = this.GetCharacter(giverName);
            var receiver = this.GetCharacter(receiverName);
            var item = giver.Bag.GetItem(itemName);

            giver.GiveCharacterItem(item, receiver);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            var sortedCharacters = this.party
                .OrderByDescending(a => a.IsAlive)
                .ThenByDescending(a => a.Health);

            var result = string.Join(Environment.NewLine, sortedCharacters);
            return result;
        }

        public string Attack(string[] args)
        {
            var attackerName = args[0];
            var defenderName = args[1];

            var attacker = GetCharacter(attackerName);
            var defender = GetCharacter(defenderName);

            if (!(attacker is IAttackable attackingCharacter))
            {
                throw new ArgumentException($"{attackerName} cannot attack!");
            }

            attackingCharacter.Attack(defender);

            var result = $"{attackerName} attacks {defenderName} for {attacker.AbilityPoints} hit points! {defenderName} has {defender.Health}/{defender.BaseHealth} HP and {defender.Armor}/{defender.BaseArmor} AP left!";

            if (!defender.IsAlive)
            {
                result += Environment.NewLine + $"{defender.Name} is dead!";
            }

            return result;
        }

        public string Heal(string[] args)
        {
            var healerName = args[0];
            var receiverName = args[1];

            var healer = GetCharacter(healerName);
            var receiver = GetCharacter(receiverName);

            if (!(healer is IHealable healingCharacter))
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }

            healingCharacter.Heal(receiver);
            var result = $"{healerName} heals {receiverName} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";

            return result;
        }

        public string EndTurn(string[] args)
        {
            var aliveCharacters = this.party.Where(c => c.IsAlive).ToArray();
            var sb = new StringBuilder();

            foreach (var character in aliveCharacters)
            {
                var health = character.Health;
                character.Rest();
                sb.AppendLine($"{character.Name} rests ({health} => {character.Health})");
            }

            if(aliveCharacters.Length <= 1)
            {
                this.lastSurvivorRounds++;
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public bool IsGameOver()
        {
            var oneOrZeroSurvivorsLeft = this.party.Count(c => c.IsAlive) <= 1;
            var lastSurviverSurvivedTooLong = this.lastSurvivorRounds > 1;

            return oneOrZeroSurvivorsLeft && lastSurviverSurvivedTooLong;
        }

        private Character GetCharacter(string name)
        {
            var character = this.party.FirstOrDefault(e => e.Name == name);

            if (character == null)
            {
                throw new ArgumentException($"Character {name} not found!");
            }

            return character;
        }
    }
}
