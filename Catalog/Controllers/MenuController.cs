using Catalog.Data;
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
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;
        public MenuController(IMenuService menuService)
        {
             _menuService = menuService;
        }
        [HttpGet("getMenu")]
        public List<Food> GetMenu(Guid restaurantId)
        {
            return _menuService.GetRestaurantsMenu(restaurantId);
        }
        [HttpPost("AddToMenu")]
        public async Task<ActionResult> AddToMenu([FromBody]RestaurantAndFood menuItem)
        {
            await _menuService.AddToMenu(menuItem);
            return Ok();
        }
        [HttpDelete("DeleteFromMenu")]
        public async Task<ActionResult> DeleteFromMenu([FromBody]RestaurantAndFood menuItem)
        {
            await _menuService.DeleteFromMenu(menuItem);
            return Ok();
        }

        [HttpGet("GetMenuByFoodCategory")]
        public List<Food> GetMenuByFoodCategory(Guid restaurantId, Guid foodCategoryId)
        {
            List<Food> fullMenu = GetMenu(restaurantId);
            List<Food> menuOfFoodCategory = new List<Food>();
            foreach (var menuItem in fullMenu)
            {
                if (menuItem.FoodCategoryId == foodCategoryId)
                {
                    menuOfFoodCategory.Add(menuItem);
                }
            }
            return menuOfFoodCategory;  
        }
    }
}
