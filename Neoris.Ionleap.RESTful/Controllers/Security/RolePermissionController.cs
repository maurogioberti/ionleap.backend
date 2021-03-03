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
    public class RolePermissionController : Controller
    {
        private readonly ILogger<RolePermissionController> _logger;
        private readonly IRolePermissionService _rolePermissionService;

        public RolePermissionController(ILogger<RolePermissionController> logger, IRolePermissionService rolePermissionService)
        {
            _logger = logger;
            _rolePermissionService = rolePermissionService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            var rolePermissions = this._rolePermissionService.GetAll();
            List<RolePermissionResponse> rolePermissionResponses = AutoMap.Map<RolePermission, RolePermissionResponse>(rolePermissions);
            return Ok(new BaseResponse<List<RolePermissionResponse>>(rolePermissionResponses));
        }

        [HttpGet("getlike")]
        public IActionResult GetLike(string like)
        {
            var rolePermissions = this._rolePermissionService.GetLike(like);
            List<RolePermissionResponse> rolePermissionResponses = AutoMap.Map<RolePermission, RolePermissionResponse>(rolePermissions);
            return Ok(new BaseResponse<List<RolePermissionResponse>>(rolePermissionResponses));
        }

        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            RolePermission rolePermission = this._rolePermissionService.Get(id);

            RolePermissionResponse rolePermissionResponse = AutoMap.Map<RolePermission, RolePermissionResponse>(rolePermission);
            return Ok(new BaseResponse<RolePermissionResponse>(rolePermissionResponse));
        }


        [HttpPut("add")]
        public IActionResult Add([FromBody]RolePermissionRequest rolePermissionRequest)
        {
            RolePermission rolePermission = AutoMap.Map<RolePermissionRequest, RolePermission>(rolePermissionRequest);
            rolePermission.Identity = default;
            this._rolePermissionService.Add(rolePermission);

            RolePermissionResponse rolePermissionResponse = AutoMap.Map<RolePermissionRequest, RolePermissionResponse>(rolePermissionRequest);
            return Ok(new BaseResponse<RolePermissionResponse>(rolePermissionResponse));
        }

        [HttpPatch("modify")]
        public IActionResult Modify([FromBody]RolePermissionRequest rolePermissionRequest)
        {
            RolePermission rolePermission = AutoMap.Map<RolePermissionRequest, RolePermission>(rolePermissionRequest);
            this._rolePermissionService.Modify(rolePermission.Identity, rolePermission);

            RolePermissionResponse rolePermissionResponse = AutoMap.Map<RolePermissionRequest, RolePermissionResponse>(rolePermissionRequest);
            return Ok(new BaseResponse<RolePermissionResponse>(rolePermissionResponse));
        }

        [HttpDelete("remove")]
        public IActionResult Remove(int id)
        {
            RolePermission rolePermission = this._rolePermissionService.Get(id);
            this._rolePermissionService.Remove(id);

            RolePermissionResponse rolePermissionResponse = AutoMap.Map<RolePermission, RolePermissionResponse>(rolePermission);
            return Ok(new BaseResponse<RolePermissionResponse>(rolePermissionResponse));
        }

    }
}