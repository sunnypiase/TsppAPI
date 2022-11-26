using Microsoft.AspNetCore.Mvc;
using TsppAPI.Models;
using TsppAPI.Models.Dtos;
using TsppAPI.Repository.Abstract;

namespace TsppAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IProductTypeRepository _typeRepository;

        public ProductController(IProductRepository repository,
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
            List<ProductType> productTypes = await GetProductTypesFromDto(productDto);
            if (productTypes.Any() is false)
            {
                return BadRequest();
            }

            var product = SetProductFromDto(productDto, productTypes);

            return await _repository.InsertAsync(product) 
                ? Ok(product) 
                : StatusCode(500, product);
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<Product>>> UpdateProduct(ProductDto productDto)
        {
            List<ProductType> productTypes = await GetProductTypesFromDto(productDto);
            if (productTypes.Any() is false)
            {
                return BadRequest();
            }

            var product = SetProductFromDto(productDto, productTypes);

            return await _repository.UpdateAsync(product)
                ? Ok(product)
                : StatusCode(500, product);
        }
        private Product SetProductFromDto(ProductDto productDto, List<ProductType> productTypes) 
            => new()
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Price = productDto.Price,
                Amount = productDto.Amount,
                Weight = productDto.Weight,
                Types = productTypes
            };
        private async Task<List<ProductType>> GetProductTypesFromDto(ProductDto productDto)
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
            return productTypes;
        }
    }
}
