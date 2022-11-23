using TsppAPI.Models;
using TsppAPI.Repository.Abstract;

namespace TsppAPI.Repository
{
    internal class SoldProductRepository
        : SqlGenericRepository<SoldProduct>,
        ISoldProductRepository
    {
        public SoldProductRepository(DataContext dataContext)
            : base(dataContext)
        { }
    }
}
