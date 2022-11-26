using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TsppAPI.Controllers;
using TsppAPI.Models;
using TsppAPI.Models.Dtos;
using TsppAPI.Repository.Abstract;
using Xunit;

namespace Tests
{
    public class PoductControllerPostTest
    {
        public ProductController ControllerMock { get; set; }
        public Mock<IProductRepository> ProductRepositoryMock { get; set; }
        public Mock<IProductTypeRepository> ProductTypeRepositoryMock { get; set; }

        public Product ProductData;
        public ProductDto ProductDtoData;

        public PoductControllerPostTest()
        {
            ProductRepositoryMock = new Mock<IProductRepository>();
            ProductTypeRepositoryMock = new Mock<IProductTypeRepository>();

            ControllerMock = new ProductController(
                ProductRepositoryMock.Object,
                ProductTypeRepositoryMock.Object);
        }
        [Fact]
        public async void PostProductSuccessTest()
        {
            SetupData(new[]
            {
                new ProductType
                {
                    Id = 1,
                    Products = null,
                    TypeName = "testType"
                }
            });

            SetupProductRepositoryMock(true);
            SetupProductTypeRepositoryMock();

            var expected = ControllerMock.Ok(ProductData);

            var actual = (await ControllerMock.PostProduct(ProductDtoData)).Result;

            var expectedJson = JsonConvert.SerializeObject(expected);
            var actualJson = JsonConvert.SerializeObject(actual);

            Assert.Equal(expectedJson, actualJson);

        }
        [Fact]
        public async void PostProductBadRequestTest()
        {
            SetupData(Array.Empty<ProductType>());

            SetupProductTypeRepositoryMock();

            var expected = ControllerMock.BadRequest();

            var actual = (await ControllerMock.PostProduct(ProductDtoData)).Result;

            var expectedJson = JsonConvert.SerializeObject(expected);
            var actualJson = JsonConvert.SerializeObject(actual);

            Assert.Equal(expectedJson, actualJson);

        }
        [Fact]
        public async void PostProductFailedTest()
        {
            SetupData(new[]
            {
                new ProductType
                {
                    Id = 1,
                    Products = null,
                    TypeName = "testType"
                }
            });
            SetupProductRepositoryMock(false);
            SetupProductTypeRepositoryMock();

            var expected = ControllerMock.StatusCode(500, ProductData);

            var actual = (await ControllerMock.PostProduct(ProductDtoData)).Result;

            var expectedJson = JsonConvert.SerializeObject(expected);
            var actualJson = JsonConvert.SerializeObject(actual);

            Assert.Equal(expectedJson, actualJson);

        }
        private void SetupProductRepositoryMock(bool result)
        {
            ProductRepositoryMock.Setup(p => p.InsertAsync(ProductData)).Returns(Task.FromResult(result));

        }
        private void SetupProductTypeRepositoryMock()
        {
            ProductType? productType = ProductData?.Types?.Any()
                ?? false
                ? ProductData?.Types.First()
                : null;
            ProductTypeRepositoryMock.Setup(p => p.GetByIdAsync(ProductDtoData.Id))
                .Returns(Task.FromResult(productType ?? null));
        }
        private void SetupData(ICollection<ProductType> types)
        {
            ProductData = new()
            {

                Id = 1,
                Name = "testName",
                Price = 1,
                Amount = 1,
                Weight = 1,
                Types = types
            };
            ProductDtoData = new()
            {
                Id = 1,
                Name = "testName",
                Price = 1,
                Amount = 1,
                Weight = 1,
                TypeIds = types.Select(x => x.Id).ToList()
            };
        }

    }
}