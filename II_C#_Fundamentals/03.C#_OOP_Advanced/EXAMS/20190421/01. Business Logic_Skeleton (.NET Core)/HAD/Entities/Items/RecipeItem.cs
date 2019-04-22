namespace HAD.Entities.Items
{
    using System.Collections.Generic;
    using System.Text;
    using HAD.Contracts;

    public class RecipeItem : BaseItem, IRecipe
    {
        private readonly List<string> requiredItems;

        public RecipeItem(
            string name,
            long strengthBonus,
            long agilityBonus,
            long intelligenceBonus,
            long hitPointsBonus,
            long damageBonus,
            List<string> requiredItems)
            : base(
                name,
                strengthBonus,
                agilityBonus,
                intelligenceBonus,
                hitPointsBonus,
                damageBonus)
        {
            this.requiredItems = new List<string>(requiredItems);
        }

        public IReadOnlyList<string> RequiredItems => this.requiredItems.AsReadOnly();
    }
}
