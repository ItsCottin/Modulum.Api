using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using modulum.Application.Interfaces.Services.Identity;
using modulum.Application.Requests.Dynamic.Create;
using modulum.Application.Requests.Identity;
using modulum.Server.Controllers;
using modulum.Application.Interfaces.Services.DynamicEntity;
using modulum.Application.Requests.Dynamic;
using modulum.Infrastructure.Services.DynamicEntity;
using modulum.Shared.Routes;
using modulum.Shared.Enum;
using modulum.Shared.Wrapper;

namespace Modulum.Api.Controllers.Dynamic
{
    //[Authorize]
    [AllowAnonymous]
    [Route(EndpointsDynamic.Raiz)]
    [ApiController]
    public class DynamicController : ControllerBase
    {
        private readonly IDynamicEntityService _dynamicEntityService;
        private readonly IDynamicTableService _dynamicTableService;

        public DynamicController(IDynamicEntityService coreEntityService, IDynamicTableService dynamicTableService)
        {
            _dynamicEntityService = coreEntityService;
            _dynamicTableService = dynamicTableService;
        }

        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Status 200 OK</returns>
        [HttpPost]
        public async Task<ActionResult> CreateDynamic(CreateDynamicTableRequest model)
        {
            var resultado = await _dynamicEntityService.CriarMapTabelaAsync(model);
            var resultado2 = await _dynamicTableService.CriarTabelaFisicaAsync(resultado.Data);
            return Ok(resultado);
        }

        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Status 200 OK</returns>
        [HttpPut("{operacao}")]
        public async Task<ActionResult> CRUDDynamic(string operacao, DynamicTableRequest model)
        {
            switch (operacao)
            {
                case "insert":
                    var insert = await _dynamicTableService.InsertAsync(model);
                    return Ok(insert);
                case "update":
                    var update = await _dynamicTableService.UpdateAsync(model);
                    return Ok(update);
                case "delete":
                    var delete = await _dynamicTableService.DeleteAsync(model);
                    return Ok(delete);
                case "select":
                    var select = await _dynamicTableService.ConsultarDinamicoAsync(model.Id);
                    return Ok(select);
            }
            return BadRequest(await Result.FailAsync($"Operação '{operacao}' inválida"));
        }

        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Status 200 OK</returns>
        [HttpGet(EndpointsDynamic.Menu)]
        public async Task<ActionResult> GetMenu()
        {
            return Ok(await _dynamicTableService.GetMenu());
        }

        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Status 200 OK</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> ConsultarDinamicoAsync(int id)
        {
            return Ok(await _dynamicTableService.ConsultarDinamicoAsync(id));
        }

        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Status 200 OK</returns>
        [HttpGet(EndpointsDynamic.GetNewObjeto + "/{id}")]
        public async Task<ActionResult> GetNewObjetoDinamico(int id)
        {
            return Ok(await _dynamicTableService.GetNewObjetoDinamico(id));
        }

        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Status 200 OK</returns>
        [HttpGet(EndpointsDynamic.GetMapTable + "/{id}")]
        public async Task<ActionResult> ConsultarMapTabelaAsync(int id)
        {
            return Ok(await _dynamicEntityService.ConsultarMapTabelaAsync(id));
        }
    }
}
