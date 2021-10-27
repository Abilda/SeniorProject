using Catalog.IServices;
using Catalog.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;
        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }
        [HttpGet("GetAll")]
        public List<Food> GetAll()
        {
            return _foodService.GetAll();
        }

        [HttpGet("Get")]
        public Food Get(Guid id)
        {
            return _foodService.Get(id);
        }
        
        [HttpPost("Create")]
        public async Task<Food> Create([FromBody] Food food)
        {
            return await _foodService.Create(food);
        }
        [HttpPut("Edit")]
        public async Task<Food> Edit([FromBody] Food food)
        {
            return await _foodService.Edit(food);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid foodId)
        {
            await _foodService.Delete(foodId);
            return Ok();
        }

        [HttpDelete("DeleteAll")]
        public async Task<IActionResult> DeleteAll()
        {
            await _foodService.DeleteAll();
            return Ok();
        }

    }
}
