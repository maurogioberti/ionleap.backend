using Neoris.Ionleap.CrossCutting.Utils.Mapper;
using Neoris.Ionleap.ResourceAccess.Entities.Security;
using Neoris.Ionleap.ResourceAccess.Requests;
using Neoris.Ionleap.ResourceAccess.Responses;
using Neoris.Ionleap.ResourceAccess.Responses.Infrastructure;
using Neoris.Ionleap.RESTful.Infrastructure.Attributes;
using Neoris.Ionleap.Services.Abstractions.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Neoris.Ionleap.ResourceAccess.Responses.Security;

namespace Neoris.Ionleap.RESTful.Controllers
{
    [ValidationFilter]
    [Authorize, Authorize(Policy = "Allowed")]
    [Route("[controller]")]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly ILogger<RoleController> _logger;
        private readonly IRoleService _roleService;

        public RoleController(ILogger<RoleController> logger, IRoleService roleService)
        {
            _logger = logger;
            _roleService = roleService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            var role = this._roleService.GetAll();
            List<RoleResponse> roleResponses = AutoMap.Map<Role, RoleResponse>(role);
            return Ok(new BaseResponse<List<RoleResponse>>(roleResponses));
        }

        [HttpGet("getlike")]
        public IActionResult GetLike(string like)
        {
            var role = this._roleService.GetLike(like);
            List<RoleResponse> roleResponses = AutoMap.Map<Role, RoleResponse>(role);
            return Ok(new BaseResponse<List<RoleResponse>>(roleResponses));
        }

        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            Role role = this._roleService.Get(id);

            RoleResponse roleResponse = AutoMap.Map<Role, RoleResponse>(role);
            return Ok(new BaseResponse<RoleResponse>(roleResponse));
        }


        [HttpPut("add")]
        public IActionResult Add([FromBody]RoleRequest budgetRequest)
        {
            Role role = AutoMap.Map<RoleRequest, Role>(budgetRequest);
            role.Identity = default;
            this._roleService.Add(role);

            RoleResponse roleResponse = AutoMap.Map<RoleRequest, RoleResponse>(budgetRequest);
            return Ok(new BaseResponse<RoleResponse>(roleResponse));
        }

        [HttpPatch("modify")]
        public IActionResult Modify([FromBody]RoleRequest budgetRequest)
        {
            Role role = AutoMap.Map<RoleRequest, Role>(budgetRequest);
            this._roleService.Modify(role.Identity, role);

            RoleResponse roleResponse = AutoMap.Map<RoleRequest, RoleResponse>(budgetRequest);
            return Ok(new BaseResponse<RoleResponse>(roleResponse));
        }

        [HttpDelete("remove")]
        public IActionResult Remove(int id)
        {
            Role role = this._roleService.Get(id);
            this._roleService.Remove(id);

            RoleResponse roleResponse = AutoMap.Map<Role, RoleResponse>(role);
            return Ok(new BaseResponse<RoleResponse>(roleResponse));
        }
    }
}
