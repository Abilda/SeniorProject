using Catalog.Data;
using Catalog.IServices;
using Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Services
{
    public class CuisineTypeService : ICuisineTypeService
    {
        private readonly CatalogDBContext _dbContext;
        public CuisineTypeService(CatalogDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<CuisineType> Create(CuisineType food)
        {
            food.Id = Guid.NewGuid();
            _dbContext.CuisineTypes.Add(food);
            await _dbContext.SaveChangesAsync();
            return food;
        }

        public CuisineType Get(Guid foodId)
        {
            return _dbContext.CuisineTypes.Find(foodId);
        }

        public List<CuisineType> GetAll()
        {
            return _dbContext.CuisineTypes.ToList();
        }
        public async Task Delete(Guid id)
        {
            try
            {
                _dbContext.CuisineTypes.Remove(_dbContext.CuisineTypes.Find(id));
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task DeleteAll()
        {
            _dbContext.CuisineTypes.RemoveRange(_dbContext.CuisineTypes.ToList());
            await _dbContext.SaveChangesAsync();
        }

        public async Task<CuisineType> Edit(CuisineType cuisineType)
        {
            await Delete(cuisineType.Id);
            return await Create(cuisineType);
        }
    }
}
