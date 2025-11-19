using IndustrialTaskZooAPI.Models;

namespace IndustrialTaskZooAPI.Feeding
{
    public class CarnivoreFeedingStrategy : IFeedingStrategy
    {
        public decimal CalculatePortion(decimal standardPortion, Animal animal) => 3m*standardPortion;

    }
}
