using IndustrialTaskZooAPI.Data.Repositories.Animals;
using IndustrialTaskZooAPI.Dtos;

namespace IndustrialTaskZooAPI.Services.Animals
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalService(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<IReadOnlyCollection<AnimalDto>> GetAllAsync(string? species = null)
        {
            var animals = string.IsNullOrWhiteSpace(species)
                ? await _animalRepository.GetAllAsync()
                : await _animalRepository.GetBySpeciesAsync(species);

            return animals
                .Select(a => new AnimalDto(
                    a.Id,
                    a.Name,
                    a.Species,
                    a.DietType.ToString()))
                .ToList()
                .AsReadOnly();
        }
    }
}
