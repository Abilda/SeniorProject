using Catalog.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.IServices
{
    public interface ICuisineTypeService
    {
        public List<CuisineType> GetAll();
        public CuisineType Get(Guid foodId);
        public Task<CuisineType> Create(CuisineType food);
        public Task Delete(Guid foodId);
        public Task DeleteAll();
        Task<CuisineType> Edit(CuisineType food);
    }
}
