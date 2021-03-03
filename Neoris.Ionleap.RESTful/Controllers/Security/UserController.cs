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
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticationRequest authenticationRequest)
        {
            if (_userService.Authenticate(authenticationRequest.Username, authenticationRequest.Password, out var token))
            {
                AuthenticationResponse authenticationResponse = new AuthenticationResponse(_userService.UserLogged, token);
                return Ok(new BaseResponse<AuthenticationResponse>(authenticationResponse));
            }

            var response = new BaseResponse<object>(false, "El usuario o contraseña no coinciden");
            return Unauthorized(response);
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            List<UserResponse> usersResponse = AutoMap.Map<User, UserResponse>(this._userService.GetAll());
            return Ok(new BaseResponse<List<UserResponse>>(usersResponse));
        }

        [HttpGet("getlike")]
        public IActionResult GetLike(string like)
        {
            List<UserResponse> usersResponse = AutoMap.Map<User, UserResponse>(this._userService.GetLike(like));
            return Ok(new BaseResponse<List<UserResponse>>(usersResponse));
        }

        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            User user = this._userService.Get(id);

            UserResponse userResponse = AutoMap.Map<User, UserResponse>(user);
            return Ok(new BaseResponse<UserResponse>(userResponse));
        }

        [HttpPut("add")]
        public IActionResult Add([FromBody]UserRequest userRequest)
        {
            User userEntity = AutoMap.Map<UserRequest, User>(userRequest);
            userEntity.Identity = default;
            this._userService.Add(userEntity);

            UserResponse userResponse = AutoMap.Map<UserRequest, UserResponse>(userRequest);
            return Ok(new BaseResponse<UserResponse>(userResponse));
        }

        [HttpPatch("modify")]
        public IActionResult Modify([FromBody]UserRequest userRequest)
        {
            User userEntity = AutoMap.Map<UserRequest, User>(userRequest);
            this._userService.Add(userEntity);

            UserResponse userResponse = AutoMap.Map<UserRequest, UserResponse>(userRequest);
            return Ok(new BaseResponse<UserResponse>(userResponse));
        }

        [HttpDelete("remove")]
        public IActionResult Remove(int id)
        {
            User userEntity = this._userService.Get(id);
            this._userService.Remove(id);
            UserResponse userResponse = AutoMap.Map<User, UserResponse>(userEntity);

            return Ok(new BaseResponse<UserResponse>(userResponse));
        }
    }
}