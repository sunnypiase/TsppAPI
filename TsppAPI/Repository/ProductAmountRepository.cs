using TsppAPI.Models;
using TsppAPI.Repository.Abstract;

namespace TsppAPI.Repository
{
    public class ProductAmountRepository : IProductAmountRepository
    {
        protected readonly DataContext _dataContext;
        protected readonly DbSet<Product> _entity;
        public ProductAmountRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
            _entity = _dataContext.Set<Product>();
        }
        public Task<int> GetProductsAmount() => _entity.CountAsync();
    }
}
