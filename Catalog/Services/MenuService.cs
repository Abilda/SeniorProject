using Catalog.Data;
using Catalog.IServices;
using Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Services
{
    public class MenuService : IMenuService
    {
        private readonly CatalogDBContext _dbContext;
        private readonly IFoodService _foodService;
        public MenuService(CatalogDBContext dbContext, IFoodService foodService)
        {
            _dbContext = dbContext;
            _foodService = foodService;
        }
        public async Task<RestaurantAndFood> AddToMenu(RestaurantAndFood menuItem)
        {
            bool alreadyInTheMenu = false;
            foreach (var existingMenuItem in _dbContext.RestaurantAndFoods.ToList())
                if (existingMenuItem.FoodId == menuItem.FoodId && existingMenuItem.RestaurantId == menuItem.RestaurantId)
                    alreadyInTheMenu = true;
            if (alreadyInTheMenu)
            {
                throw new Exception("Given food is already on the menu");
            }
            menuItem.Id = Guid.NewGuid();
            _dbContext.RestaurantAndFoods.Add(menuItem);
            await _dbContext.SaveChangesAsync();
            return menuItem;
        }

        public async Task DeleteFromMenu(RestaurantAndFood menuItem)
        {
            _dbContext.RestaurantAndFoods.Remove(menuItem);
            await _dbContext.SaveChangesAsync();
        }

        public List<Food> GetRestaurantsMenu(Guid restaurantsId)
        {
            List<Food> restaurantsMenu = new List<Food>();
            foreach (var menuItem in _dbContext.RestaurantAndFoods.ToList())
            {
                if (menuItem.RestaurantId == restaurantsId)
                {
                    restaurantsMenu.Add(_foodService.Get((Guid)menuItem.FoodId));
                }
            }
            return restaurantsMenu;
        }
    }
}
