using modulum.Application.Interfaces.Services;
using modulum.Application.Interfaces.Services.Identity;
using modulum.Application.Requests.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using modulum.Infrastructure.Models.Identity;
using modulum.Shared.Routes;

namespace modulum.Server.Controllers.Identity
{
    [Route(EndpointsToken.Raiz)]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _identityService;
        private readonly SignInManager<ModulumUser> _signInManager;

        public TokenController(ITokenService identityService, ICurrentUserService currentUserService, SignInManager<ModulumUser> signInManager)
        {
            _identityService = identityService;
            _signInManager = signInManager;
        }

        /// <summary>
        /// Get Token (Email, Password)
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Status 200 OK</returns>
        [HttpPost(EndpointsToken.Login)]
        public async Task<ActionResult> Get(TokenRequest model)
        {
            var response = await _identityService.LoginAsync(model);
            return Ok(response);
        }

        /// <summary>
        /// Refresh Token
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Status 200 OK</returns>
        [HttpPost(EndpointsToken.Refresh)]
        public async Task<ActionResult> Refresh([FromBody] RefreshTokenRequest model)
        {
            var response = await _identityService.GetRefreshTokenAsync(model);
            return Ok(response);
        }

        /// <summary>
        /// Refresh Token
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Status 200 OK</returns>
        [Authorize]
        [HttpPost(EndpointsToken.Logout)]
        public async Task<ActionResult> Logout([FromBody] object empty)
        {
            if (empty is not null)
            {
                await _signInManager.SignOutAsync();
            }
            return Ok();
        }


    }
}