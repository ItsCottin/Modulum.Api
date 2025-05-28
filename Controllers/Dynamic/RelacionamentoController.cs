using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using modulum.Application.Interfaces.Services.DynamicEntity;
using modulum.Application.Requests.Dynamic;
using modulum.Application.Requests.Dynamic.Relationship;
using modulum.Shared.Routes;

namespace Modulum.Api.Controllers.Dynamic
{

    [Authorize]
    //[AllowAnonymous]
    [Route(EndpointsRelacionamento.Raiz)]
    [ApiController]
    public class RelacionamentoController : ControllerBase
    {
        private readonly IDynamicEntityService _dynamicEntityService;
        private readonly IDynamicTableService _dynamicTableService;

        public RelacionamentoController(IDynamicEntityService coreEntityService, IDynamicTableService dynamicTableService)
        {
            _dynamicEntityService = coreEntityService;
            _dynamicTableService = dynamicTableService;
        }

        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Status 200 OK</returns>
        [HttpPost(EndpointsRelacionamento.AlterarRelacionamento)]
        public async Task<ActionResult> AlterRelacionamento(List<CreateDynamicRelationshipRequest> model)
        {
            return Ok(await _dynamicEntityService.AlterRelacionamento(model));
        }

        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status 200 OK</returns>
        [HttpGet(EndpointsRelacionamento.ConsultarRelacionamento + "/{id}")]
        public async Task<ActionResult> ConsultarRelacionamento(int id)
        {
            return Ok(await _dynamicEntityService.ConsultarRelacionamento(id));
        }

        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Status 200 OK</returns>
        [HttpPost(EndpointsRelacionamento.DeletarRelacionamento)]
        public async Task<ActionResult> DeletarRelacionamento(DynamicForIdRequest model)
        {
            return Ok(await _dynamicEntityService.DeletarRelacionamento(model));

        }
    }
}