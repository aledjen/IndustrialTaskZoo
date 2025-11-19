using IndustrialTaskZooAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace IndustrialTaskZooAPI.Data.Repositories.Animals
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly AppDbContext _db;

        public AnimalRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IReadOnlyCollection<Animal>> GetAllAsync()
        {
            return await _db.Animals.AsNoTracking().ToListAsync();
        }

        public async Task<IReadOnlyCollection<Animal>> GetBySpeciesAsync(string species)
        {
            return await _db.Animals.AsNoTracking().Where(a => a.Species.Equals(species, StringComparison.OrdinalIgnoreCase)).ToListAsync();
        }
    }
}
