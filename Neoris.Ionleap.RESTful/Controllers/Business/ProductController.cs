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
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            var product = this._productService.GetAll();
            List<ProductResponse> productResponses = AutoMap.Map<Product, ProductResponse>(product);
            return Ok(new BaseResponse<List<ProductResponse>>(productResponses));
        }

        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            Product product = this._productService.Get(id);

            ProductResponse productResponse = AutoMap.Map<Product, ProductResponse>(product);
            return Ok(new BaseResponse<ProductResponse>(productResponse));
        }

        [HttpGet("getlike")]
        public IActionResult GetLike(string like)
        {
            var product = this._productService.GetLike(like);
            List<ProductResponse> productResponses = AutoMap.Map<Product, ProductResponse>(product);
            return Ok(new BaseResponse<List<ProductResponse>>(productResponses));
        }

        [HttpPut("add")]
        public IActionResult Add([FromBody]ProductRequest productRequest)
        {
            Product product = AutoMap.Map<ProductRequest, Product>(productRequest);
            product.Identity = default;
            this._productService.Add(product);

            ProductResponse productResponse = AutoMap.Map<ProductRequest, ProductResponse>(productRequest);
            return Ok(new BaseResponse<ProductResponse>(productResponse));
        }

        [HttpPatch("modify")]
        public IActionResult Modify([FromBody]ProductRequest productRequest)
        {
            Product product = AutoMap.Map<ProductRequest, Product>(productRequest);
            this._productService.Modify(product.Identity, product);

            ProductResponse productResponse = AutoMap.Map<ProductRequest, ProductResponse>(productRequest);
            return Ok(new BaseResponse<ProductResponse>(productResponse));
        }

        [HttpDelete("remove")]
        public IActionResult Remove(int id)
        {
            Product product = this._productService.Get(id);
            this._productService.Remove(id);

            ProductResponse productResponse = AutoMap.Map<Product, ProductResponse>(product);
            return Ok(new BaseResponse<ProductResponse>(productResponse));
        }
    }
}
