using TsppAPI.Models;
using TsppAPI.Repository.Abstract;

namespace TsppAPI.Repository
{
    internal class ProductRepository
        : SqlGenericRepository<Product>,
        IProductRepository
    {
        private readonly IProductTypeRepository _typeRepository;

        public ProductRepository(DataContext dataContext,
            IProductTypeRepository typeRepository)
            : base(dataContext)
        {
            _typeRepository = typeRepository;
        }        
    }
}
