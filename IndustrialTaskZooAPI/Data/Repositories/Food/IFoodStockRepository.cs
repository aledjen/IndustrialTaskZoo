namespace IndustrialTaskZooAPI.Data.Repositories.Food
{
    public interface IFoodStockRepository
    {
        Task<decimal> GetQuantityAsync();
        Task UpdateQuantityAsync(decimal quantity);
    }
}
