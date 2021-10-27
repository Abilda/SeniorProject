using Catalog.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.IServices
{
    public interface IRestaurantAndCuisineTypeService
    {
        public List<CuisineType> GetRestaurantsCuisineTypes(Guid restaurantsId);
        public Task<RestaurantsAndCuisineType> AddCuisineTypeToRestaurant(RestaurantsAndCuisineType cuisineTypeAtRestaurant);
        public Task DeleteCuisineTypeFromRestaurant(RestaurantsAndCuisineType cuisineTypeAtRestaurant);
    }
}
