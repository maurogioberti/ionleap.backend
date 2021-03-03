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
    public class BrandController : Controller
    {
        private readonly ILogger<BrandController> _logger;
        private readonly IBrandService _brandService;

        public BrandController(ILogger<BrandController> logger, IBrandService brandService)
        {
            _logger = logger;
            _brandService = brandService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            var brand = this._brandService.GetAll();
            List<BrandResponse> brandResponses = AutoMap.Map<Brand, BrandResponse>(brand);
            return Ok(new BaseResponse<List<BrandResponse>>(brandResponses));
        }

        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            Brand brand = this._brandService.Get(id);

            BrandResponse brandResponses = AutoMap.Map<Brand, BrandResponse>(brand);
            return Ok(new BaseResponse<BrandResponse>(brandResponses));
        }


        [HttpPut("add")]
        public IActionResult Add([FromBody]BrandRequest brandRequest)
        {
            Brand brand = AutoMap.Map<BrandRequest, Brand>(brandRequest);
            brand.Identity = default;

            BrandResponse brandResponses = AutoMap.Map<Brand, BrandResponse>(this._brandService.Add(brand));
            return Ok(new BaseResponse<BrandResponse>(brandResponses));
        }

        [HttpPatch("modify")]
        public IActionResult Modify([FromBody]BrandRequest brandRequest)
        {
            Brand brand = AutoMap.Map<BrandRequest, Brand>(brandRequest);
            this._brandService.Modify(brand.Identity, brand);

            BrandResponse brandResponses = AutoMap.Map<BrandRequest, BrandResponse>(brandRequest);
            return Ok(new BaseResponse<BrandResponse>(brandResponses));
        }

        [HttpDelete("remove")]
        public IActionResult Remove(int id)
        {
            Brand brand = this._brandService.Get(id);
            this._brandService.Remove(id);

            BrandResponse brandResponses = AutoMap.Map<Brand, BrandResponse>(brand);
            return Ok(new BaseResponse<BrandResponse>(brandResponses));
        }


        [HttpGet("getlike")]
        public IActionResult GetLike(string like)
        {
            var brand = this._brandService.GetLike(like);
            List<BrandResponse> brandResponses = AutoMap.Map<Brand, BrandResponse>(brand);
            return Ok(new BaseResponse<List<BrandResponse>>(brandResponses));
        }

    }
}
