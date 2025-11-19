using IndustrialTaskZooAPI.Dtos;

namespace IndustrialTaskZooAPI.Services.Foods
{
    public interface IFoodStockService
    {
        Task<FoodStockDto> GetAsync();
        Task<FoodStockDto> PurchaseAsync(decimal amount);
        Task<FoodStockDto> FeedAllAnimalsAsync();
    }
}
