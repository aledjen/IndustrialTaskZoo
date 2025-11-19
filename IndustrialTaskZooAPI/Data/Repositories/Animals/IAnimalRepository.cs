using IndustrialTaskZooAPI.Models;

namespace IndustrialTaskZooAPI.Data.Repositories.Animals
{
    public interface IAnimalRepository
    {
        Task<IReadOnlyCollection<Animal>> GetAllAsync();
        Task<IReadOnlyCollection<Animal>> GetBySpeciesAsync(string species);
    }
}
