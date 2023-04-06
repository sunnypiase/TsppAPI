using System;
namespace TsppAPI.Services.Abstract
{
    public interface IAuthorizationService
    {
        public bool IsRightCredentials(string login, string password);
    }
}
