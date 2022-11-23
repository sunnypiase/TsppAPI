using TsppAPI.Models;
using TsppAPI.Repository.Abstract;

namespace TsppAPI.Repository
{
    internal class ProductTypeRepository
        : SqlGenericRepository<ProductType>,
        IProductTypeRepository
    {
        public ProductTypeRepository(DataContext dataContext)
            : base(dataContext)
        { }
    }
}
