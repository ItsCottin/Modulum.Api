using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using modulum.Application.Interfaces.Services.Identity;
using modulum.Application.Requests.Versao;
using modulum.Shared.Routes;
using RCF.Modulum.Application.Interfaces.Services;
using System.Data;

namespace modulum.Controllers.Versao
{
    [Authorize]
    [Route(EndpointGetVersao.Raiz)]
    [ApiController]
    public class VersaoController : ControllerBase
    {
        private readonly IVersao _iversao;

        public VersaoController(IVersao iversao)
        { 
            _iversao = iversao;
        }

        /// <summary>
        /// Get Users Details
        /// </summary>
        /// <returns>Status 200 OK</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllVersao()
        {
            var result = await _iversao.GetAllVersao();
            return Ok(result);
        }

        /// <summary>
        /// Get Users Details
        /// </summary>
        /// <returns>Status 200 OK</returns>
        [Authorize(Roles = "Sistema")]
        [HttpPost(EndpointGetVersao.Update)]
        public async Task<IActionResult> Update(PackageListResultRequest request)
        {
            var result = await _iversao.AddEditPacotes(request);
            return Ok();
        }
    }
}
