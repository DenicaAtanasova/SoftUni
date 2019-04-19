using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly List<ICard> cards;

        public CardRepository()
        {
            this.cards = new List<ICard>();
        }

        public int Count => this.Cards.Count;

        public IReadOnlyCollection<ICard> Cards => this.cards.AsReadOnly();

        public void Add(ICard card)
        {
            this.CheckIfCardIsNull(card);

            if (this.Cards.Any(c => c.Name == card.Name))
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }

            this.cards.Add(card);
        }

        public ICard Find(string name)
        {
            var card = this.Cards.FirstOrDefault(c => c.Name == name);
            CheckIfCardIsNull(card);

            return card;
        }

        public bool Remove(ICard card)
        {
            this.CheckIfCardIsNull(card);

            return this.cards.Remove(card);
        }

        private void CheckIfCardIsNull(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }
        }
    }
}
