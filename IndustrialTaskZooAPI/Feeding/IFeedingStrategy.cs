using IndustrialTaskZooAPI.Models;

namespace IndustrialTaskZooAPI.Feeding
{
    public interface IFeedingStrategy
    {
        decimal CalculatePortion(decimal standardPortion, Animal animal);
    }
}
