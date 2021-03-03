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

namespace Neoris.Ionleap.RESTful.Controllers
{
    [ValidationFilter]
    [Authorize, Authorize(Policy = "Allowed")]
    [Route("[controller]")]
    [ApiController]
    public class UserRoleController : Controller
    {
        private readonly ILogger<UserRoleController> _logger;
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(ILogger<UserRoleController> logger, IUserRoleService userRoleService)
        {
            _logger = logger;
            _userRoleService = userRoleService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            var userRole = this._userRoleService.GetAll();
            List<UserRoleResponse> userRoleResponses = AutoMap.Map<UserRole, UserRoleResponse>(userRole);
            return Ok(new BaseResponse<List<UserRoleResponse>>(userRoleResponses));
        }

        [HttpGet("getlike")]
        public IActionResult GetLike(string like)
        {
            var userRole = this._userRoleService.GetLike(like);
            List<UserRoleResponse> userRoleResponses = AutoMap.Map<UserRole, UserRoleResponse>(userRole);
            return Ok(new BaseResponse<List<UserRoleResponse>>(userRoleResponses));
        }

        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            UserRole userRole = this._userRoleService.Get(id);

            UserRoleResponse userRoleResponse = AutoMap.Map<UserRole, UserRoleResponse>(userRole);
            return Ok(new BaseResponse<UserRoleResponse>(userRoleResponse));
        }


        [HttpPut("add")]
        public IActionResult Add([FromBody]UserRoleRequest userRoleRequest)
        {
            UserRole userRole = AutoMap.Map<UserRoleRequest, UserRole>(userRoleRequest);
            userRole.Identity = default;
            this._userRoleService.Add(userRole);

            UserRoleResponse userRoleResponse = AutoMap.Map<UserRoleRequest, UserRoleResponse>(userRoleRequest);
            return Ok(new BaseResponse<UserRoleResponse>(userRoleResponse));
        }

        [HttpPatch("modify")]
        public IActionResult Modify([FromBody]UserRoleRequest userRoleRequest)
        {
            UserRole userRole = AutoMap.Map<UserRoleRequest, UserRole>(userRoleRequest);
            this._userRoleService.Modify(userRole.Identity, userRole);

            UserRoleResponse userRoleResponse = AutoMap.Map<UserRoleRequest, UserRoleResponse>(userRoleRequest);
            return Ok(new BaseResponse<UserRoleResponse>(userRoleResponse));
        }

        [HttpDelete("remove")]
        public IActionResult Remove(int id)
        {
            UserRole userRole = this._userRoleService.Get(id);
            this._userRoleService.Remove(id);

            UserRoleResponse userRoleResponse = AutoMap.Map<UserRole, UserRoleResponse>(userRole);
            return Ok(new BaseResponse<UserRoleResponse>(userRoleResponse));
        }

    }
}
