using Catalog.Data;
using Catalog.IServices;
using Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Services
{
    public class FoodCategoryService : IFoodCategoryService
    {
        private readonly CatalogDBContext _dbContext;
        public FoodCategoryService(CatalogDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<FoodCategory> Create(FoodCategory foodCategory)
        {
            foodCategory.Id = Guid.NewGuid();
            _dbContext.FoodCategories.Add(foodCategory);
            await _dbContext.SaveChangesAsync();
            return foodCategory;
        }

        public FoodCategory Get(Guid foodCategoryId)
        {
            return _dbContext.FoodCategories.Find(foodCategoryId);
        }

        public List<FoodCategory> GetAll()
        {
            return _dbContext.FoodCategories.ToList();
        }
        public async Task Delete(Guid id)
        {
            try
            {
                _dbContext.FoodCategories.Remove(_dbContext.FoodCategories.Find(id));
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task DeleteAll()
        {
            _dbContext.FoodCategories.RemoveRange(_dbContext.FoodCategories.ToList());
            await _dbContext.SaveChangesAsync();
        }

        public async Task<FoodCategory> Edit(FoodCategory foodCategory)
        {
            await Delete(foodCategory.Id);
            return await Create(foodCategory);
        }
    }
}
