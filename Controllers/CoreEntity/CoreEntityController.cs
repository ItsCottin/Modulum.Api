using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using modulum.Application.Interfaces.Services.Identity;
using modulum.Server.Controllers;
using RCF.Modulum.Application.Interfaces.Services.CoreEntity;

namespace Modulum.Api.Controllers.CoreEntity
{
    [Authorize]
    [Route("CoreEntity")]
    [ApiController]
    public class CoreEntityController : ControllerBase
    {
        private readonly ICoreEntityService _coreEntityService;
        private readonly IDynamicTableService _dynamicTableService;

        public CoreEntityController(ICoreEntityService coreEntityService, IDynamicTableService dynamicTableService)
        {
            _coreEntityService = coreEntityService;
            _dynamicTableService = dynamicTableService;
        }
    }
}
