using IndustrialTaskZooAPI.Dtos;
using IndustrialTaskZooAPI.Services.Animals;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IndustrialTaskZooAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalService _animalService;

        public AnimalsController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpGet("by-species")]
        public async Task<ActionResult<IReadOnlyCollection<AnimalDto>>> GetAllBySpecies([FromQuery] string? species)
        {
            var animals = await _animalService.GetAllAsync(species);
            return Ok(animals);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<AnimalDto>>> GetAll()
        {
            var animals = await _animalService.GetAllAsync();
            return Ok(animals);
        }
    }
}
