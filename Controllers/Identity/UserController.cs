using modulum.Application.Interfaces.Services.Identity;
using modulum.Application.Requests.Identity;
using modulum.Shared.Constants.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using modulum.Infrastructure.Models.Identity;
using nodulum.Application.Requests.Identity;
using modulum.Shared.Routes;
using modulum.Application.Requests.Account;
using modulum.Application.Interfaces.Services;

namespace modulum.Server.Controllers.Identity
{
    [Authorize]
    [Route(EndpointsUser.Raiz)]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<ModulumUser> _userManager;
        private readonly ICurrentUserService _currentUser;

        public UserController(IUserService userService, UserManager<ModulumUser> userManager, ICurrentUserService currentUser)
        {
            _userService = userService;
            _userManager = userManager;
            _currentUser = currentUser;
        }

        /// <summary>
        /// Get Users Details
        /// </summary>
        /// <returns>Status 200 OK</returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        /// <summary>
        /// Get User By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status 200 OK</returns>
        //[Authorize(Policy = Permissions.Users.View)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetAsync(id);
            return Ok(user);
        }

        /// <summary>
        /// Get User Roles By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status 200 OK</returns>
        //[Authorize(Policy = Permissions.Users.View)]
        //[HttpGet("roles/{id}")]
        //public async Task<IActionResult> GetRolesAsync(string id)
        //{
        //    var userRoles = await _userService.GetRolesAsync(id);
        //    return Ok(userRoles);
        //}

        /// <summary>
        /// Update Roles for User
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Status 200 OK</returns>
        //[Authorize(Policy = Permissions.Users.Edit)]
        //[HttpPut("roles/{id}")]
        //public async Task<IActionResult> UpdateRolesAsync(UpdateUserRolesRequest request)
        //{
        //    return Ok(await _userService.UpdateRolesAsync(request));
        //}

        /// <summary>
        /// Register a User
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Status 200 OK</returns>
        [AllowAnonymous]
        [HttpPost(EndpointsUser.CadastroExterno)]
        public async Task<IActionResult> CadastroExternoAsync(CadastroExternoRequest request)
        {
            return Ok(await _userService.CadastroExterno(request));
        }

        /// <summary>
        /// Register a User
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Status 200 OK</returns>
        [AllowAnonymous]
        [HttpPost(EndpointsUser.PreCadastro)]
        public async Task<IActionResult> PreRegisterAsync(PreRegisterRequest request)
        {
            var origin = Request.Headers["origin"];
            return Ok(await _userService.PreRegisterAsync(request, origin));
        }

        /// <summary>
        /// Reset Password
        /// </summary>
        /// <param name="userId"></param>
        /// /// <param name="token"></param>
        /// <returns>Status 200 OK</returns>
        [HttpPost(EndpointsUser.ConfirmEmail)]
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmailAsync(TwoFactorRequest twoFactorRequest)
        {
            var response = await _userService.ConfirmEmailAsync(twoFactorRequest);
            return Ok(response);
        }

        /// <summary>
        /// Register a User
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Status 200 OK</returns>
        [AllowAnonymous]
        [HttpPost(EndpointsUser.FimCadastro)]
        public async Task<IActionResult> FimRegisterAsync(FinishRegisterRequest request)
        {
            var origin = Request.Headers["origin"];
            return Ok(await _userService.FimRegisterAsync(request, origin));
        }

        /// <summary>
        /// Confirm Email
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="code"></param>
        /// <returns>Status 200 OK</returns>
        //[HttpGet("confirm-email")]
        //[AllowAnonymous]
        //public async Task<IActionResult> ConfirmEmailAsync([FromQuery] string userId, [FromQuery] string code)
        //{
        //    return Ok(await _userService.ConfirmEmailAsync(userId, code));
        //}

        /// <summary>
        /// Toggle User Status (Activate and Deactivate)
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Status 200 OK</returns>
        //[HttpPost("toggle-status")]
        //public async Task<IActionResult> ToggleUserStatusAsync(ToggleUserStatusRequest request)
        //{
        //    return Ok(await _userService.ToggleUserStatusAsync(request));
        //}

        /// <summary>
        /// Forgot Password
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Status 200 OK</returns>
        [HttpPost(EndpointsUser.EsqueciSenha)]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPasswordAsync(ForgotPasswordRequest request)
        {
            var origin = Request.Headers["origin"];
            return Ok(await _userService.ForgotPasswordAsync(request, origin));
        }

        /// <summary>
        /// Reset Password
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Status 200 OK</returns>
        [HttpPost(EndpointsUser.ResetarSenha)]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPasswordAsync(ResetPasswordRequest request)
        {
            return Ok(await _userService.ResetPasswordAsync(request));
        }

        /// <summary>
        /// Refresh Token
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Status 200 OK</returns>
        [Authorize]
        [HttpPost(EndpointsUser.Info)]
        public async Task<IActionResult> GetUserInfo()
        {
            var user = await _userManager.GetUserAsync(User);
            return Ok();
        }

        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Status 200 OK</returns>
        [HttpPut(EndpointsUser.ChangePassword)]
        public async Task<ActionResult> ChangePassword(ChangePasswordRequest model)
        {
            var response = await _userService.ChangePasswordAsync(model, _currentUser.UserId);
            return Ok(response);
        }



        /// <summary>
        /// Reset Password
        /// </summary>
        /// <param name="email"></param>
        /// <returns>Status 200 OK</returns>
        [HttpGet(EndpointsUser.IsEmailConfirmed)]
        [AllowAnonymous]
        public async Task<ActionResult> IsConfirmedAccountAsync(string email)
        {
            var response = await _userService.IsEmailConfirmed(email);
            return Ok(response);
        }
    }
}