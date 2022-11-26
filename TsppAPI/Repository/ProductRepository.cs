using TsppAPI.Models;
using TsppAPI.Repository.Abstract;

namespace TsppAPI.Repository
{
    internal class ProductRepository
        : SqlGenericRepository<Product>,
        IProductRepository
    {
        public ProductRepository(DataContext dataContext)
            : base(dataContext)
        { }

        public override async Task<bool> UpdateAsync(Product entityToUpdate)
        {
            Product productToUpdate = await _entity.Include(p => p.Types).FirstOrDefaultAsync(x => x.Id == entityToUpdate.Id);
            if (productToUpdate is null) return false;

            productToUpdate.Types.Clear();

            foreach (var type in entityToUpdate.Types)
            {
                productToUpdate.Types.Add(type);
            }
            productToUpdate.Name = entityToUpdate.Name;
            productToUpdate.Price = entityToUpdate.Price;
            productToUpdate.Weight = entityToUpdate.Weight;
            productToUpdate.Amount = entityToUpdate.Amount;

            await _dataContext.SaveChangesAsync();
            return true;
        }
    }
}
