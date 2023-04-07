using Microsoft.AspNetCore.Mvc;
using TsppAPI.Models.Dtos;
using TsppAPI.Models;
using TsppAPI.Providers.Abstract;
using TsppAPI.Services.Abstract;

namespace TsppAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;

        public AuthorizationController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }
        [HttpPost]
        public ActionResult<Product> AuthorizeUser(AuthorizationDto authorizationDto)
            => _authorizationService.IsRightCredentials(authorizationDto)
                 ? Ok("Success")
                 : NotFound("User not found");
    }
}
