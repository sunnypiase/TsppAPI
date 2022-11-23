using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using TsppAPI.Controllers;
using TsppAPI.Models;
using TsppAPI.Repository.Abstract;
using Xunit;
using static TsppAPI.Controllers.PoductController;

namespace Tests
{
    public class PoductControllerTest
    {
        public PoductController ControllerMock { get; set; }
        public Mock<IProductRepository> productRepositoryMock { get; set; }
        public Mock<IProductTypeRepository> producTypeRepositoryMock { get; set; }
        public Product ProductData = new()
        {

            Id = 1,
            Name = "testName",
            Price = 1,
            Amount = 1,
            Weight = 1,
            Types = new[]
                {
                    new ProductType
                    {
                        Id=1,
                        Products = null,
                        TypeName ="testType"
                    }
                }
        };
        public ProductDto ProductDtoData = new()
        {
            Id = 1,
            Name = "testName",
            Price = 1,
            Amount = 1,
            Weight = 1,
            TypeIds = new[] { 1 }
        };
        public PoductControllerTest()
        {
            productRepositoryMock = new Mock<IProductRepository>();
            producTypeRepositoryMock = new Mock<IProductTypeRepository>();

            SetupMocks();

            ControllerMock = new PoductController(
                productRepositoryMock.Object,
                producTypeRepositoryMock.Object);
        }
        [Fact]
        public async void PostProductSuccessTest()
        {
            var expected = ControllerMock.Ok(ProductData);
            var actual = (await ControllerMock.PostProduct(ProductDtoData)).Result;
            var expectedJson = JsonConvert.SerializeObject(expected);
            var actualJson = JsonConvert.SerializeObject(actual);
            Assert.Equal(expectedJson, actualJson);

        }
        private void SetupMocks()
        {
            var tr = Task.FromResult(true);
            productRepositoryMock.Setup(p => p.InsertAsync(ProductData)).Returns(tr);
            ProductType productType = ProductData.Types.First();
            producTypeRepositoryMock.Setup(p => p.GetByIdAsync(ProductDtoData.Id))
                .Returns(Task.FromResult(productType ?? null));
        }

    }
}