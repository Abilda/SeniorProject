using Catalog.IServices;
using Catalog.Models;
using System;
using System.Collections.Generic;

namespace Catalog.Helpers
{
    public class RestaurantsMenuAndInfoInitializerHelper
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IRestaurantAndCuisineTypeService _restaurantAndCuisineTypeService;
        private readonly IMenuService _menuService;
        private readonly IFoodCategoryService _foodCategoryService;
        public RestaurantsMenuAndInfoInitializerHelper(IRestaurantService restaurantService, IRestaurantAndCuisineTypeService restaurantAndCuisineTypeService,
            IMenuService menuService, IFoodCategoryService foodCategoryService)
        {
            _restaurantService = restaurantService;
            _restaurantAndCuisineTypeService = restaurantAndCuisineTypeService;
            _menuService = menuService;
            _foodCategoryService = foodCategoryService;
        }
        public RestaurantMenuAndInfo GetMenuAndInfo(Guid restaurantId)
        {
            RestaurantMenuAndInfo restaurantInfoWithMenu = new RestaurantMenuAndInfo();

            restaurantInfoWithMenu.RestaurantInfo = _restaurantService.Get(restaurantId);
            InitMenuByFoodCategory(restaurantInfoWithMenu);
            InitCuisineTypes(restaurantInfoWithMenu);
            restaurantInfoWithMenu.Rating = 9.5;

            return restaurantInfoWithMenu;
        }
        private void InitMenuByFoodCategory(RestaurantMenuAndInfo restaurantInfoWithMenu)
        {
            List<Food> menu = _menuService.GetRestaurantsMenu(restaurantInfoWithMenu.RestaurantInfo.Id);
            restaurantInfoWithMenu.MenuByFoodCategory = new Dictionary<string, List<Food>>();

            foreach (var menuItem in menu)
            {
                string foodCategoryName = _foodCategoryService.Get(menuItem.FoodCategoryId).Name;
                if (!restaurantInfoWithMenu.MenuByFoodCategory.ContainsKey(foodCategoryName))
                    restaurantInfoWithMenu.MenuByFoodCategory.Add(foodCategoryName, new List<Food>());
                restaurantInfoWithMenu.MenuByFoodCategory[foodCategoryName].Add(menuItem);
            }
        }
        private void InitCuisineTypes(RestaurantMenuAndInfo restaurantInfoWithMenu)
        {
            List<CuisineType> restaurantsCuisineTypes = _restaurantAndCuisineTypeService.GetRestaurantsCuisineTypes(
                restaurantInfoWithMenu.RestaurantInfo.Id);
            foreach (var cuisineTypeItem in restaurantsCuisineTypes)
            {
                if (restaurantInfoWithMenu.CuisineTypes == null)
                {
                    restaurantInfoWithMenu.CuisineTypes = new List<string>();
                }
                restaurantInfoWithMenu.CuisineTypes.Add(cuisineTypeItem.Name);
            }
        }
    }
}
