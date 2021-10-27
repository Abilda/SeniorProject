using Catalog.Data;
using Catalog.IServices;
using Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Services
{
    public class RestaurantService : IRestaurantService
    {
        private CatalogDBContext _dbContext;
        public RestaurantService(CatalogDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Restaurant> Create(Restaurant restaurant)
        {
            restaurant.Id = Guid.NewGuid();
            _dbContext.Restaurants.Add(restaurant);
            await _dbContext.SaveChangesAsync();
            return restaurant;
        }
        public async Task Delete(Guid id)
        {
            try
            {
                _dbContext.Restaurants.Remove(_dbContext.Restaurants.Find(id));
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task DeleteAll()
        {
            _dbContext.Restaurants.RemoveRange(_dbContext.Restaurants.ToList());
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Restaurant> Edit(Restaurant restaurant)
        {
            await Delete(restaurant.Id);
            return await Create(restaurant);
        }

        public Restaurant Get(Guid id)
        {
            return _dbContext.Restaurants.Find(id);
        }

        public List<Restaurant> GetAll()
        {
            return _dbContext.Restaurants.ToList();
        }
    }
}
