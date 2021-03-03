using Neoris.Ionleap.CrossCutting.Utils.Mapper;
using Neoris.Ionleap.ResourceAccess.Entities.Business;
using Neoris.Ionleap.ResourceAccess.Requests.Business;
using Neoris.Ionleap.ResourceAccess.Responses.Business;
using Neoris.Ionleap.ResourceAccess.Responses.Infrastructure;
using Neoris.Ionleap.RESTful.Infrastructure.Attributes;
using Neoris.Ionleap.Services.Abstractions.Business;
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
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            var customer = this._customerService.GetAll();
            List<CustomerResponse> customerResponses = AutoMap.Map<Customer, CustomerResponse>(customer);
            return Ok(new BaseResponse<List<CustomerResponse>>(customerResponses));
        }

        [HttpGet("getlike")]
        public IActionResult GetLike(string like)
        {
            var customer = this._customerService.GetLike(like);
            List<CustomerResponse> customerResponses = AutoMap.Map<Customer, CustomerResponse>(customer);
            return Ok(new BaseResponse<List<CustomerResponse>>(customerResponses));
        }

        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            Customer customer = this._customerService.Get(id);

            CustomerResponse customerResponse = AutoMap.Map<Customer, CustomerResponse>(customer);
            return Ok(new BaseResponse<CustomerResponse>(customerResponse));
        }


        [HttpPut("add")]
        public IActionResult Add([FromBody]CustomerRequest customerRequest)
        {
            Customer customer = AutoMap.Map<CustomerRequest, Customer>(customerRequest);

            CustomerResponse customerResponse = AutoMap.Map<Customer, CustomerResponse>(this._customerService.Add(customer));
            return Ok(new BaseResponse<CustomerResponse>(customerResponse));
        }

        [HttpPatch("modify")]
        public IActionResult Modify([FromBody]CustomerRequest customerRequest)
        {
            Customer customer = AutoMap.Map<CustomerRequest, Customer>(customerRequest);
            this._customerService.Modify(customer.Identity, customer);

            CustomerResponse customerResponse = AutoMap.Map<CustomerRequest, CustomerResponse>(customerRequest);
            return Ok(new BaseResponse<CustomerResponse>(customerResponse));
        }

        [HttpDelete("remove")]
        public IActionResult Remove(int id)
        {
            Customer customer = this._customerService.Get(id);
            this._customerService.Remove(id);

            CustomerResponse customerResponse = AutoMap.Map<Customer, CustomerResponse>(customer);
            return Ok(new BaseResponse<CustomerResponse>(customerResponse));
        }
    }
}
