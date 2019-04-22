namespace CosmosX.Tests
{
    using CosmosX.Entities.Containers;
    using CosmosX.Entities.Modules.Absorbing;
    using CosmosX.Entities.Modules.Absorbing.Contracts;
    using CosmosX.Entities.Modules.Energy;
    using CosmosX.Entities.Modules.Energy.Contracts;
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ModuleContainerTests
    {
        [Test]
        public void AddEnergyModuleShouldThrowError()
        {
            var container = new ModuleContainer(10);
            IEnergyModule energyModule = null;

            Assert.Throws<ArgumentException>(() => container.AddEnergyModule(energyModule));
        }

        [Test]
        public void AddEnergyModuleShouldRemoveOldestModule()
        {
            var container = new ModuleContainer(3);
            var energyModule1 = new CryogenRod(1, 100);
            var energyModule2 = new CryogenRod(2, 100);
            var energyModule3 = new CryogenRod(3, 100);
            var energyModule4 = new CryogenRod(4, 100);

            container.AddEnergyModule(energyModule1);
            container.AddEnergyModule(energyModule2);
            container.AddEnergyModule(energyModule3);
            container.AddEnergyModule(energyModule4);

            Assert.AreEqual(300, container.TotalEnergyOutput);
            Assert.AreEqual(3, container.ModulesByInput.Count);
            Assert.AreEqual(2, container.ModulesByInput.First().Id);
        }

        [Test]
        public void AddAbsorbingModuleShouldThrowError()
        {
            var container = new ModuleContainer(10);
            IAbsorbingModule absorbingModule = null;

            Assert.Throws<ArgumentException>(() => container.AddAbsorbingModule(absorbingModule));
        }

        [Test]
        public void AddAbsorbingModuleShouldRemoveOldestModule()
        {
            var container = new ModuleContainer(3);
            var absorbingModule1 = new HeatProcessor(1, 100);
            var absorbingModule2 = new HeatProcessor(2, 100);
            var absorbingModule3 = new HeatProcessor(3, 100);
            var absorbingModule4 = new HeatProcessor(4, 100);

            container.AddAbsorbingModule(absorbingModule1);
            container.AddAbsorbingModule(absorbingModule2);
            container.AddAbsorbingModule(absorbingModule3);
            container.AddAbsorbingModule(absorbingModule4);

            Assert.AreEqual(300, container.TotalHeatAbsorbing);
            Assert.AreEqual(3, container.ModulesByInput.Count);
            Assert.AreEqual(2, container.ModulesByInput.First().Id);
        }
    }
}