using TsppAPI.Models.Dtos;
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
        public bool IsRightCredentials(AuthorizationDto authorizationDto) => 
            _currentDbUserProvider.Username == authorizationDto.Login
            && _currentDbUserProvider.Password == authorizationDto.Password;
    }
}
