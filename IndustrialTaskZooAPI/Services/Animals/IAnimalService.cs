using IndustrialTaskZooAPI.Dtos;

namespace IndustrialTaskZooAPI.Services.Animals
{
    public interface IAnimalService
    {
        Task<IReadOnlyCollection<AnimalDto>> GetAllAsync(string? species = null);
    }
}
