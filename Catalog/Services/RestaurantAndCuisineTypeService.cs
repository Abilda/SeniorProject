using Catalog.Data;
using Catalog.IServices;
using Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Services
{
    public class RestaurantAndCuisineTypeService : IRestaurantAndCuisineTypeService
    {
        private readonly CatalogDBContext _dbContext;
        private readonly ICuisineTypeService _cuisineTypeService;
        public RestaurantAndCuisineTypeService(CatalogDBContext dbContext, ICuisineTypeService cuisineTypeService)
        {
            _dbContext = dbContext;
            _cuisineTypeService = cuisineTypeService;
        }
        public async Task<RestaurantsAndCuisineType> AddCuisineTypeToRestaurant(RestaurantsAndCuisineType cuisineTypeAtRestaurant)
        {
            bool cuisineTypeIsAlreadyInARestaurant = false;
            foreach (var item in _dbContext.RestaurantsAndCuisineTypes.ToList())
                if (item.CuisineTypeId == cuisineTypeAtRestaurant.CuisineTypeId && item.RestaurantId == cuisineTypeAtRestaurant.RestaurantId)
                    cuisineTypeIsAlreadyInARestaurant = true;
            if (cuisineTypeIsAlreadyInARestaurant) {
                throw new Exception("Cuisine type is already present at the restaurant");
            }
            cuisineTypeAtRestaurant.Id = Guid.NewGuid();
            _dbContext.RestaurantsAndCuisineTypes.Add(cuisineTypeAtRestaurant);
            await _dbContext.SaveChangesAsync();
            return cuisineTypeAtRestaurant;
        }

        public async Task DeleteCuisineTypeFromRestaurant(RestaurantsAndCuisineType cuisineTypeAtRestaurant)
        {
            _dbContext.RestaurantsAndCuisineTypes.Remove(cuisineTypeAtRestaurant);
            await _dbContext.SaveChangesAsync();
        }

        public List<CuisineType> GetRestaurantsCuisineTypes(Guid restaurantsId)
        {
            List<CuisineType> restaurantCuisineTypes = new List<CuisineType>();
            foreach (var restaurantCuisineType in _dbContext.RestaurantsAndCuisineTypes.ToList())
            {
                if (restaurantCuisineType.RestaurantId == restaurantsId)
                    restaurantCuisineTypes.Add(_cuisineTypeService.Get(restaurantCuisineType.CuisineTypeId));
            }
            return restaurantCuisineTypes;
        }
    }
}
