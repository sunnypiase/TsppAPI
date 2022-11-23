using TsppAPI.Models;
using TsppAPI.Repository.Abstract;

namespace TsppAPI.Repository
{
    internal class StorageProductRepository
        : SqlGenericRepository<StorageProduct>,
        IStorageProductRepository
    {
        public StorageProductRepository(DataContext dataContext)
            : base(dataContext)
        {
        }
    }
}
