using Microsoft.AspNetCore.Mvc;
using TsppAPI.Models;
using TsppAPI.Repository.Abstract;

namespace TsppAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PoductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IProductTypeRepository _typeRepository;

        public PoductController(IProductRepository repository,
            IProductTypeRepository typeRepository)
        {
            _repository = repository;
            _typeRepository = typeRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var result = await _repository.GetAsync(includeProperties: new[] { "Types" });
            return result?.Any()
                ?? false
                ? Ok(result)
                : NotFound();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductById(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            return result is not null
                ? Ok(result)
                : NotFound();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<IEnumerable<Product>>> DeleteProductById(int id)
            => await _repository.DeleteAsync(id)
                ? Ok()
                : BadRequest();

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(ProductDto productDto)
        {
            List<ProductType> productTypes = new List<ProductType>();
            foreach (var TypeId in productDto.TypeIds)
            {
                var productType = await _typeRepository.GetByIdAsync(TypeId);
                if (productType != null)
                {
                    productTypes.Add(productType);
                }
            }
            if (productTypes.Any() is false)
            {
                return BadRequest();
            }
            var product = new Product
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Price = productDto.Price,
                Amount = productDto.Amount,
                Weight = productDto.Weight,
                Types = productTypes
            };
            if (await _repository.InsertAsync(product))
            {
                return Ok(product);
            }
            return StatusCode(500, product);
        }
        [HttpPut]
        public async Task<ActionResult<IEnumerable<Product>>> UpdateProduct(ProductDto productDto)
        {
            List<ProductType> productTypes = new List<ProductType>();
            foreach (var TypeId in productDto.TypeIds)
            {
                var productType = await _typeRepository.GetByIdAsync(TypeId);
                if (productType != null)
                {
                    productTypes.Add(productType);
                }
            }
            if (productTypes.Any() is false)
            {
                return BadRequest();
            }
            var product = new Product
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Price = productDto.Price,
                Amount = productDto.Amount,
                Weight = productDto.Weight,
                Types = productTypes
            };
            if (await _repository.UpdateAsync(product))
            {
                return Ok(product);
            }
            return StatusCode(500, product);
        }
        public record ProductDto
        {
            public int Id { get; init; }
            public string Name { get; init; } = string.Empty;
            public double Price { get; init; }
            public int Amount { get; init; }
            public double Weight { get; init; }
            public ICollection<int>? TypeIds { get; init; }

        }

    }
}
