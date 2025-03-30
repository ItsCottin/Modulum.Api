using modulum.Application.Interfaces.Services;
using modulum.Application.Interfaces.Services.Account;
using modulum.Application.Requests.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Azure;

namespace modulum.Server.Controllers.Identity
{
    [Authorize]
    [Route("api/identity/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ICurrentUserService _currentUser;

        public AccountController(IAccountService accountService, ICurrentUserService currentUser)
        {
            _accountService = accountService;
            _currentUser = currentUser;
        }

        /// <summary>
        /// Update Profile
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Status 200 OK</returns>
        //[HttpPut(nameof(UpdateProfile))]
        //public async Task<ActionResult> UpdateProfile(UpdateProfileRequest model)
        //{
        //    var response = await _accountService.UpdateProfileAsync(model, _currentUser.UserId);
        //    return Ok(response);
        //}

        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Status 200 OK</returns>
        [HttpPut(nameof(ChangePassword))]
        public async Task<ActionResult> ChangePassword(ChangePasswordRequest model)
        {
            var response = await _accountService.ChangePasswordAsync(model, _currentUser.UserId);
            return Ok(response);
        }

        /// <summary>
        /// Reset Password
        /// </summary>
        /// <param name="userId"></param>
        /// /// <param name="token"></param>
        /// <returns>Status 200 OK</returns>
        [HttpGet("confirmEmail")]
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmailAsync(string userId, string token)
        {
            var response = await _accountService.ConfirmEmail(userId, token);
            return Ok(response);
        }

        /// <summary>
        /// Reset Password
        /// </summary>
        /// <param name="email"></param>
        /// <returns>Status 200 OK</returns>
        [HttpGet("isConfirmedEmail")]
        [AllowAnonymous]
        public async Task<ActionResult> isConfirmedAccountAsync(string email)
        {
            var response = await _accountService.IsEmailConfirmed(email);
            return Ok(response);
        }
    }
}