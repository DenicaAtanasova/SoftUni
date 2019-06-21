namespace P03_BarraksWars.Core.Commands
{
    using _03BarracksFactory.Contracts;
    using P03_BarraksWars.Attributes;

    public class RetireCommand : Command
    {
        [Inject]
        private IRepository repository;

        public RetireCommand(string[] data)
            :base(data)
        {
        }

        public override string Execute()
        {
            var unitToRemove = this.Data[1];
            this.repository.RemoveUnit(unitToRemove);

            return $"{unitToRemove} retired!";
        }
    }
}