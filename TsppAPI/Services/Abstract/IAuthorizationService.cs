using System;
using TsppAPI.Models.Dtos;

namespace TsppAPI.Services.Abstract
{
    public interface IAuthorizationService
    {
        public bool IsRightCredentials(AuthorizationDto authorizationDto);
    }
}
