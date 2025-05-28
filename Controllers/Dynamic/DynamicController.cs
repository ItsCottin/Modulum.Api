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
using modulum.Application.Requests.Dynamic.Update;
using modulum.Application.Requests.Dynamic.Relationship;

namespace Modulum.Api.Controllers.Dynamic
{
    [Authorize]
    //[AllowAnonymous]
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
                    return BadRequest(await Result.FailAsync($"Operação '{operacao}' removida, utilize o entpoint '/dynamic/del-for-id'"));
                case "select":
                    var select = await _dynamicTableService.ConsultaTodosPorIdTabelaAsync(model.Id);
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
        /// <param name="id"></param>
        /// <returns>Status 200 OK</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> ConsultaTodosPorIdTabelaAsync(int id)
        {
            return Ok(await _dynamicTableService.ConsultaTodosPorIdTabelaAsync(id));
        }

        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="id"></param>
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
        [HttpPost(EndpointsDynamic.SelectDynamicById)]
        public async Task<ActionResult> SelectDynamicById(DynamicForIdRequest model)
        {
            return Ok(await _dynamicTableService.ConsultaRegistroPorIdTabelaEIdRegistroAsync(model));
        }

        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Status 200 OK</returns>
        [HttpPost(EndpointsDynamic.DeleteDynamicById)]
        public async Task<ActionResult> DeleteDynamicById(DynamicForIdRequest model)
        {
            return Ok(await _dynamicTableService.DeletePorIdAsync(model));
        }

        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Status 200 OK</returns>
        [HttpPost(EndpointsDynamic.AlterMapTable)]
        public async Task<ActionResult> AlterMapTableAsync(CreateDynamicTableRequest model)
        {
            return Ok(await _dynamicEntityService.AlterMapTableAsync(model));
        }

        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status 200 OK</returns>
        [HttpGet(EndpointsDynamic.GetMapTable + "/{id}")]
        public async Task<ActionResult> ConsultarMapTabelaAsync(int id)
        {
            return Ok(await _dynamicEntityService.ConsultarMapTabelaAsync(id));
        }

        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Status 200 OK</returns>
        [HttpPost(EndpointsDynamic.RenameNomeTabelaTela)]
        public async Task<ActionResult> RenameNomeTabelaTelaAsync(RenameNomeTabelaTelaRequest model)
        {
            return Ok(await _dynamicEntityService.RenameNomeTabelaTelaAsync(model));
        }

        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Status 200 OK</returns>
        [HttpDelete(EndpointsDynamic.DeleteMapTable + "/{IdTable}")]
        public async Task<ActionResult> DeleteMapTableAsync(int IdTable)
        {
            return Ok(await _dynamicEntityService.DeleteMapTableAsync(IdTable));
        }
    }
}
