using Neoris.Ionleap.ResourceAccess.Entities.Security;
using Neoris.Ionleap.ResourceAccess.Responses.Infrastructure;
using Neoris.Ionleap.RESTful.Infrastructure.Attributes;
using Neoris.Ionleap.Services.Abstractions.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Neoris.Ionleap.RESTful.Controllers
{
    [ValidationFilter]
    [Authorize, Authorize(Policy = "Allowed")]
    [Route("[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly ILogger<PermissionController> _logger;
        private readonly IPermissionService _permissionService;

        public PermissionController(ILogger<PermissionController> logger, IPermissionService permissionService)
        {
            _logger = logger;
            _permissionService = permissionService;
        }

        [HttpGet("{name}")]
        public IActionResult Get()
        {
            List<Permission> permission = _permissionService.GetAll();
            var response = new BaseResponse<List<Permission>>();
            return Ok(response);
        }

        //// GET: api/Permission/5
        //[HttpGet("{id}", Name = "Get")]
        //public IActionResult Get(int id)
        //{
        //    Ok("");
        //}

        //// POST: api/Permission
        //[HttpPost]
        //public IActionResult Post([FromBody] string value)
        //{
        //    Ok();
        //}

        //// PUT: api/Permission/5
        //[HttpPut("{id}")]
        //public IActionResult Add([FromBody] string value)
        //{
        //    Ok();
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public IActionResult Remove(int id)
        //{
        //    Ok();
        //}
    }
}
