using Catalog.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.IServices
{
    public interface IMenuService
    {
        public List<Food> GetRestaurantsMenu(Guid restaurantsId);
        public Task<RestaurantAndFood> AddToMenu(RestaurantAndFood menuItem);
        public Task DeleteFromMenu(RestaurantAndFood menuItem);
    }
}
