using Catalog.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.IServices
{
    public interface IFoodService
    {
        public List<Food> GetAll();
        public Food Get(Guid foodId);
        public Task<Food> Create(Food food);
        public Task Delete(Guid foodId);
        public Task DeleteAll();
        Task<Food> Edit(Food food);
    }
}
