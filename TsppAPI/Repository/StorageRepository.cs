using TsppAPI.Models;
using TsppAPI.Repository.Abstract;

namespace TsppAPI.Repository
{
    internal class StorageRepository
        : SqlGenericRepository<Storage>,
        IStorageRepository
    {
        public StorageRepository(DataContext dataContext)
            : base(dataContext)
        { }
    }
}
