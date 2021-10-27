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
    public class RestaurantAndCuisineTypesController : ControllerBase
    {
        private readonly IRestaurantAndCuisineTypeService _restaurantAndCuisineTypeService;
        public RestaurantAndCuisineTypesController(IRestaurantAndCuisineTypeService restaurantAndCuisineTypeService)
        {
            _restaurantAndCuisineTypeService = restaurantAndCuisineTypeService;
        }
        
        [HttpGet("GetCuisineTypes")]
        public List<CuisineType> GetCuisineTypes(Guid restaurantId)
        {
            return _restaurantAndCuisineTypeService.GetRestaurantsCuisineTypes(restaurantId);
        }

        [HttpPost("AddCuisineType")]
        public async Task<RestaurantsAndCuisineType> AddCuisineType(RestaurantsAndCuisineType cuisineTypeAtRestaurant)
        {
            return await _restaurantAndCuisineTypeService.AddCuisineTypeToRestaurant(cuisineTypeAtRestaurant);
        }
    }
}
