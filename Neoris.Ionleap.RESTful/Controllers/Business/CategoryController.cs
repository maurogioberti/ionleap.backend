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
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _categoryService;

        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            var category = this._categoryService.GetAll();
            List<CategoryResponse> categoryResponses = AutoMap.Map<Category, CategoryResponse>(category);
            return Ok(new BaseResponse<List<CategoryResponse>>(categoryResponses));
        }

        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            Category category = this._categoryService.Get(id);

            CategoryResponse categoryResponses = AutoMap.Map<Category, CategoryResponse>(category);
            return Ok(new BaseResponse<CategoryResponse>(categoryResponses));
        }


        [HttpPut("add")]
        public IActionResult Add([FromBody]CategoryRequest categoryRequest)
        {
            Category category = AutoMap.Map<CategoryRequest, Category>(categoryRequest);

            CategoryResponse categoryResponses = AutoMap.Map<Category, CategoryResponse>(this._categoryService.Add(category));
            return Ok(new BaseResponse<CategoryResponse>(categoryResponses));
        }

        [HttpPatch("modify")]
        public IActionResult Modify([FromBody]CategoryRequest categoryRequest)
        {
            Category category = AutoMap.Map<CategoryRequest, Category>(categoryRequest);
            category.Identity = default;
            this._categoryService.Modify(category.Identity, category);

            CategoryResponse categoryResponses = AutoMap.Map<CategoryRequest, CategoryResponse>(categoryRequest);
            return Ok(new BaseResponse<CategoryResponse>(categoryResponses));
        }

        [HttpDelete("remove")]
        public IActionResult Remove(int id)
        {
            Category category = this._categoryService.Get(id);
            this._categoryService.Remove(id);

            CategoryResponse categoryResponses = AutoMap.Map<Category, CategoryResponse>(category);
            return Ok(new BaseResponse<CategoryResponse>(categoryResponses));
        }


        [HttpGet("getlike")]
        public IActionResult GetLike(string like)
        {
            var category = this._categoryService.GetLike(like);
            List<CategoryResponse> categoryResponses = AutoMap.Map<Category, CategoryResponse>(category);
            return Ok(new BaseResponse<List<CategoryResponse>>(categoryResponses));
        }

    }
}
