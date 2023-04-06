using TsppAPI.Providers.Abstract;
using TsppAPI.Services.Abstract;

namespace TsppAPI.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly ICurrentDbUserProvider _currentDbUserProvider;

        public AuthorizationService(ICurrentDbUserProvider currentDbUserProvider)
        {
            _currentDbUserProvider = currentDbUserProvider;
        }
        public bool IsRightCredentials(string login, string password) => 
            _currentDbUserProvider.Username == login
            && _currentDbUserProvider.Password == password;
    }
}
