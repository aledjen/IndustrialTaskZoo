using IndustrialTaskZooAPI.Dtos;
using IndustrialTaskZooAPI.Services.Foods;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IndustrialTaskZooAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodStockController : ControllerBase
    {
        private readonly IFoodStockService _foodStockService;

        public FoodStockController(IFoodStockService foodStockService)
        {
            _foodStockService = foodStockService;
        }

        [HttpGet]
        public async Task<ActionResult<FoodStockDto>> Get()
        {
            var stock = await _foodStockService.GetAsync();
            return Ok(stock);
        }

        [HttpPost("purchase")]
        public async Task<ActionResult<FoodStockDto>> Purchase([FromBody] PurchaseFoodRequestDto request)
        {
            var updated = await _foodStockService.PurchaseAsync(request.Amount);
            return Ok(updated);
        }

        [HttpPost("feed")]
        public async Task<ActionResult<FoodStockDto>> FeedAll()
        {
            try
            {
                var updated = await _foodStockService.FeedAllAnimalsAsync();
                return Ok(updated);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
