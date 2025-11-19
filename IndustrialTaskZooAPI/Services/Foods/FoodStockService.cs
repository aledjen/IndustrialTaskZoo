using IndustrialTaskZooAPI.Data.Repositories.Animals;
using IndustrialTaskZooAPI.Data.Repositories.Food;
using IndustrialTaskZooAPI.Dtos;
using IndustrialTaskZooAPI.Feeding;

namespace IndustrialTaskZooAPI.Services.Foods
{
    public class FoodStockService : IFoodStockService
    {
        private const decimal StandardPortion = 1m;

        private readonly IFoodStockRepository _foodStockRepository;
        private readonly IAnimalRepository _animalRepository;
        private readonly IFeedingStrategyFactory _feedingStrategyFactory;

        public FoodStockService(
            IFoodStockRepository foodStockRepository,
            IAnimalRepository animalRepository,
            IFeedingStrategyFactory feedingStrategyFactory)
        {
            _foodStockRepository = foodStockRepository;
            _animalRepository = animalRepository;
            _feedingStrategyFactory = feedingStrategyFactory;
        }

        public async Task<FoodStockDto> GetAsync()
        {
            var quantity = await _foodStockRepository.GetQuantityAsync();
            return new FoodStockDto(quantity);
        }

        public async Task<FoodStockDto> PurchaseAsync(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be positive.");
            }

            var current = await _foodStockRepository.GetQuantityAsync();
            var updated = current + amount;

            await _foodStockRepository.UpdateQuantityAsync(updated);

            return new FoodStockDto(updated);
        }

        public async Task<FoodStockDto> FeedAllAnimalsAsync()
        {
            var animals = await _animalRepository.GetAllAsync();
            var current = await _foodStockRepository.GetQuantityAsync();

            var totalRequired = animals.Sum(animal =>
            {
                var strategy = _feedingStrategyFactory.GetStrategy(animal);
                return strategy.CalculatePortion(StandardPortion, animal);
            });

            if (totalRequired > current)
            {
                throw new InvalidOperationException("Not enough food to feed all animals.");
            }

            var updated = current - totalRequired;
            await _foodStockRepository.UpdateQuantityAsync(updated);

            return new FoodStockDto(updated);
        }
    }
}
