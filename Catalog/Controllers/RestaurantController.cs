using Catalog.Helpers;
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
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IRestaurantAndCuisineTypeService _restaurantAndCuisineTypeService;
        private readonly IMenuService _menuService;
        private readonly IFoodCategoryService _foodCategoryService;
        public RestaurantController(IRestaurantService restaurantService, IRestaurantAndCuisineTypeService restaurantAndCuisineTypeService,
            IMenuService menuService, IFoodCategoryService foodCategoryService)
        {
            _restaurantService = restaurantService;
            _restaurantAndCuisineTypeService = restaurantAndCuisineTypeService;
            _menuService = menuService;
            _foodCategoryService = foodCategoryService;
        }

        [HttpGet("GetMenuAndInfo")]
        public RestaurantMenuAndInfo GetMenuAndInfo(Guid restaurantId)
        {
            RestaurantsMenuAndInfoInitializerHelper initializerHelper = new RestaurantsMenuAndInfoInitializerHelper(_restaurantService, 
                _restaurantAndCuisineTypeService, _menuService, _foodCategoryService);
            return initializerHelper.GetMenuAndInfo(restaurantId);
        }

        [HttpGet("getAll")]
        public List<Restaurant> GetAll()
        {
            return _restaurantService.GetAll();
        }

        [HttpPost("Create")]
        public async Task<Restaurant> Create([FromBody]Restaurant restaurant)
        {
            return await _restaurantService.Create(restaurant);
        }
        [HttpPut("Edit")]
        public async Task<Restaurant> Edit([FromBody] Restaurant restaurant)
        {
            return await _restaurantService.Edit(restaurant);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid restaurantId)
        {
            await _restaurantService.Delete(restaurantId);
            return Ok();
        }

        [HttpDelete("DeleteAll")]
        public async Task<IActionResult> DeleteAll()
        {
            await _restaurantService.DeleteAll();
            return Ok();
        }


    }
}
