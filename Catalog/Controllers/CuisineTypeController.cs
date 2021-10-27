using Catalog.IServices;
using Catalog.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuisineTypeController : ControllerBase
    {
        private readonly ICuisineTypeService _cuisineTypeService;
        public CuisineTypeController(ICuisineTypeService cuisineTypeService)
        {
            _cuisineTypeService = cuisineTypeService;
        }
        [HttpGet("GetAll")]
        public List<CuisineType> GetAll()
        {
            return _cuisineTypeService.GetAll();
        }

        [HttpGet("Get")]
        public CuisineType Get(Guid id)
        {
            return _cuisineTypeService.Get(id);
        }

        [HttpPost("Create")]
        public async Task<CuisineType> Create([FromBody] CuisineType cuisineType)
        {
            return await _cuisineTypeService.Create(cuisineType);
        }
        [HttpPut("Edit")]
        public async Task<CuisineType> Edit([FromBody] CuisineType cuisineType)
        {
            return await _cuisineTypeService.Edit(cuisineType);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid cuisineTypeId)
        {
            await _cuisineTypeService.Delete(cuisineTypeId);
            return Ok();
        }

        [HttpDelete("DeleteAll")]
        public async Task<IActionResult> DeleteAll()
        {
            await _cuisineTypeService.DeleteAll();
            return Ok();
        }
    }
}
