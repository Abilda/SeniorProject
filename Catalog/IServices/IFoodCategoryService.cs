using Catalog.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.IServices
{
    public interface IFoodCategoryService
    {
        public List<FoodCategory> GetAll();
        public FoodCategory Get(Guid foodId);
        public Task<FoodCategory> Create(FoodCategory food);
        public Task Delete(Guid foodId);
        public Task DeleteAll();
        Task<FoodCategory> Edit(FoodCategory food);
    }
}
