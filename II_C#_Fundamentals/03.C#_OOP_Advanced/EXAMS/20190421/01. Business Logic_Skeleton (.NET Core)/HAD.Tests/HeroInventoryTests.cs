using HAD.Entities.Items;
using HAD.Contracts;
using HAD.Entities.Miscellaneous;
using NUnit.Framework;
using System.Collections.Generic;

namespace HAD.Tests
{
    public class HeroInventoryTests
    {
        private IInventory heroInventory;

        [SetUp]
        public void Setup()
        {
            this.heroInventory = new HeroInventory();
        }

        [Test]
        public void AddCommonItemTests()
        {
            var item = new CommonItem("Knife", 10, 10, 10, 10, 10);
            this.heroInventory.AddCommonItem(item);

            Assert.AreEqual(1, this.heroInventory.CommonItems.Count);
            Assert.AreEqual(10, this.heroInventory.TotalAgilityBonus);
            Assert.AreEqual(10, this.heroInventory.TotalDamageBonus);
            Assert.AreEqual(10, this.heroInventory.TotalHitPointsBonus);
            Assert.AreEqual(10, this.heroInventory.TotalIntelligenceBonus);
            Assert.AreEqual(10, this.heroInventory.TotalStrengthBonus);
        }

        [Test]
        public void AddRecipeItemTests()
        {
            var knifeItem = new CommonItem("Knife", 10, 10, 10, 10, 10);
            var stickItem = new CommonItem("Stick", 20, 20, 20, 20, 20);
            this.heroInventory.AddCommonItem(knifeItem);
            this.heroInventory.AddCommonItem(stickItem);

            var recipeItem = new RecipeItem("NewItem", 100, 100, 100, 100, 100, new List<string> { "Knife", "Stick" });
            this.heroInventory.AddRecipeItem(recipeItem);

            Assert.AreEqual(1, this.heroInventory.CommonItems.Count);
            Assert.AreEqual(100, this.heroInventory.TotalAgilityBonus);
            Assert.AreEqual(100, this.heroInventory.TotalDamageBonus);
            Assert.AreEqual(100, this.heroInventory.TotalHitPointsBonus);
            Assert.AreEqual(100, this.heroInventory.TotalIntelligenceBonus);
            Assert.AreEqual(100, this.heroInventory.TotalStrengthBonus);
        }

        [Test]
        public void AddRecipeItem2Tests()
        {
            var knifeItem = new CommonItem("Knife", 10, 10, 10, 10, 10);
            this.heroInventory.AddCommonItem(knifeItem);

            var recipeItem = new RecipeItem("NewItem", 100, 100, 100, 100, 100, new List<string> { "Knife", "Stick" });
            this.heroInventory.AddRecipeItem(recipeItem);

            Assert.AreEqual(1, this.heroInventory.CommonItems.Count);
            Assert.AreEqual(10, this.heroInventory.TotalAgilityBonus);
            Assert.AreEqual(10, this.heroInventory.TotalDamageBonus);
            Assert.AreEqual(10, this.heroInventory.TotalHitPointsBonus);
            Assert.AreEqual(10, this.heroInventory.TotalIntelligenceBonus);
            Assert.AreEqual(10, this.heroInventory.TotalStrengthBonus);
        }
    }
}