using IndustrialTaskZooAPI.Models;
using IndustrialTaskZooAPI.Models.Enums;

namespace IndustrialTaskZooAPI.Feeding
{
    public class FeedingStrategyFactory : IFeedingStrategyFactory
    {
        private readonly IFeedingStrategy _carnivoreStrategy = new CarnivoreFeedingStrategy();
        private readonly IFeedingStrategy _herbivoreStrategy = new HerbivoreFeedingStrategy();



        public IFeedingStrategy GetStrategy(Animal animal)
        {

            return animal.DietType switch
            {
                DietType.Carnivore => _carnivoreStrategy,
                DietType.Herbivore => _herbivoreStrategy,
                _ => _herbivoreStrategy //throw exception if needed
            };
        }
    }
}
