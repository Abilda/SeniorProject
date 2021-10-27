using Catalog.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.IServices
{
    public interface IRestaurantService
    {
        public List<Restaurant> GetAll();
        public Restaurant Get(Guid id);
        public Task<Restaurant> Create(Restaurant restaurant);
        public Task Delete(Guid id);
        public Task DeleteAll();
        Task<Restaurant> Edit(Restaurant restaurant);
    }
}
