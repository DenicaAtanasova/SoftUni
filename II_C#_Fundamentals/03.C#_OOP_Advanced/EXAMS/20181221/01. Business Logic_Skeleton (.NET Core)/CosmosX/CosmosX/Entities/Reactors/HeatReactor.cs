namespace CosmosX.Entities.Reactors
{
    using Containers.Contracts;

    public class HeatReactor : BaseReactor
    {
        public HeatReactor(int id, IContainer moduleContainer, int heatReductionIndex)
            : base(id, moduleContainer)
        {
            this.HeatReductionIndex = heatReductionIndex;
        }

        public int HeatReductionIndex { get;}

        public override long TotalHeatAbsorbing 
            => base.TotalHeatAbsorbing + this.HeatReductionIndex;
    }
}