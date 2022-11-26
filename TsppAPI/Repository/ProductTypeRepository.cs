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

        public override async Task<ProductType?> GetByIdAsync(int id)
        {
            return await _entity.Include("Products").FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
