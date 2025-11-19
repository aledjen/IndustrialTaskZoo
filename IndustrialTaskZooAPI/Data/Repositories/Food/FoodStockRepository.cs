namespace IndustrialTaskZooAPI.Data.Repositories.Food
{
    public class FoodStockRepository : IFoodStockRepository
    {
        private decimal _quantity = 0m;
        private readonly object _lock = new();

        public Task<decimal> GetQuantityAsync()
        {
            lock (_lock)
            {
                return Task.FromResult(_quantity);
            }
        }

        public Task UpdateQuantityAsync(decimal quantity)
        {
            lock (_lock)
            {
                _quantity = quantity;
            }

            return Task.CompletedTask;
        }
    }
}
