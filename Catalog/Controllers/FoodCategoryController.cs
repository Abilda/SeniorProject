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
    public class FoodCategoryController : ControllerBase
    {
        private readonly IFoodCategoryService _foodCategoryService;
        public FoodCategoryController(IFoodCategoryService foodCategoryService)
        {
            _foodCategoryService = foodCategoryService;
        }

        [HttpGet("GetAll")]
        public List<FoodCategory> GetAll()
        {
            return _foodCategoryService.GetAll();
        }

        [HttpGet("Get")]
        public FoodCategory Get(Guid id)
        {
            return _foodCategoryService.Get(id);
        }

        [HttpPost("Create")]
        public async Task<FoodCategory> Create([FromBody] FoodCategory foodCategory)
        {
            return await _foodCategoryService.Create(foodCategory);
        }

        [HttpPut("Edit")]
        public async Task<FoodCategory> Edit([FromBody] FoodCategory foodCategory)
        {
            return await _foodCategoryService.Edit(foodCategory);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid foodCategoryId)
        {
            await _foodCategoryService.Delete(foodCategoryId);
            return Ok();
        }

        [HttpDelete("DeleteAll")]
        public async Task<IActionResult> DeleteAll()
        {
            await _foodCategoryService.DeleteAll();
            return Ok();
        }
    }
}
