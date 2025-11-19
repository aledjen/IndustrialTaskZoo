using IndustrialTaskZooAPI.Models;

namespace IndustrialTaskZooAPI.Feeding
{
    public interface IFeedingStrategyFactory
    {
        IFeedingStrategy GetStrategy(Animal animal);
    }
}

