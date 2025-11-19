using IndustrialTaskZooAPI.Models;

namespace IndustrialTaskZooAPI.Feeding
{
    public class HerbivoreFeedingStrategy : IFeedingStrategy
    {
        public decimal CalculatePortion(decimal standardPortion, Animal animal)
        {
            if (animal.IsGiraffe) return standardPortion;
            else return 0.5m * standardPortion;
        }
    }
}
