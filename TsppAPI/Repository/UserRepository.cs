using TsppAPI.Models;
using TsppAPI.Repository.Abstract;

namespace TsppAPI.Repository
{
    internal class UserRepository
        : SqlGenericRepository<User>,
        IUserRepository
    {
        public UserRepository(DataContext dataContext)
            : base(dataContext)
        { }
    }
}
