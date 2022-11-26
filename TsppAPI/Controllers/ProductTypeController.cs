using Microsoft.AspNetCore.Mvc;
using TsppAPI.Models;
using TsppAPI.Repository.Abstract;

namespace TsppAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeRepository _typeRepository;

        public ProductTypeController(IProductTypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductType>>> GetTypes()
        {
            var result = await _typeRepository.GetAsync();
            return result?.Any()
                ?? false
                ? Ok(result)
                : NotFound();
        }
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(ProductTypeDto productTypeDto)
        {
           
            var product = new ProductType
            {
                Id = 0,
                TypeName = productTypeDto.TypeName,
                Products = Array.Empty<Product>()
            };
            if (await _typeRepository.InsertAsync(product))
            {
                return Ok(product);
            }
            return StatusCode(500, product);
        }
    }
    public record ProductTypeDto
    {
        public string TypeName { get; init; } = string.Empty;

    }
}
