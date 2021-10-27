using Catalog.Data;
using Catalog.IServices;
using Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Services
{
    public class FoodService : IFoodService
    {
        private readonly CatalogDBContext _dbContext;
        public FoodService(CatalogDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Food> Create(Food food)
        {
            food.Id = Guid.NewGuid();
            _dbContext.Foods.Add(food);
            await _dbContext.SaveChangesAsync();
            return food;
        }

        public Food Get(Guid foodId)
        {
            return _dbContext.Foods.Find(foodId);
        }

        public List<Food> GetAll()
        {
            return _dbContext.Foods.ToList();
        }
        public async Task Delete(Guid id)
        {
            try
            {
                _dbContext.Foods.Remove(_dbContext.Foods.Find(id));
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        public async Task DeleteAll()
        {
            _dbContext.Foods.RemoveRange(_dbContext.Foods.ToList());
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Food> Edit(Food food)
        {
            await Delete(food.Id);
            return await Create(food);
        }
    }
}
