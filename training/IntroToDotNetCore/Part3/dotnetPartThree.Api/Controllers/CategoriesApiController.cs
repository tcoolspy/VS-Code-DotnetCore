using System;
using System.Linq;
using dotnetPartThree.Core.Framework.Contracts;
using dotnetPartThree.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace dotnetPartThree.Api.Controllers
{
    public class CategoriesApiController : BaseApiController
    {
        protected readonly IGenericBusinessService<Category, int> _categoryService;
        
        public CategoriesApiController(LinkGenerator linkGenerator,
                                       IGenericBusinessService<Category, int> categoryService) : base(linkGenerator)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException("categoryService");
        }

        /// <summary>
        /// Retrieves a category based on the Category Id.
        /// </summary>
        /// <param name="id">The id of the Category</param>
        /// <returns>A entity of type Category.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     api/category/1
        /// 
        /// </remarks>
        /// <response code="200">Returns the Category</response>
        /// <response code="400">If the category is not found</response>
        [HttpGet]
        [Route("api/category/{id:int}")]
        public IActionResult Get(int id)
        {
            var response = _categoryService.DataRepository.Get(id);
            if (response != null)
            {
                var category = TheModelFactory.Create(response);
                return Ok(category);                
            }

            return NotFound();
        }

        /// <summary>
        /// Retrieves all categories
        /// </summary>
        /// <returns>A list of categories</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     api/category
        ///
        /// </remarks>
        [HttpGet]
        [Route("api/category")]
        public IActionResult GetAll()
        
        {
            var response = _categoryService.DataRepository.GetAll();
            var categories = response.Select(x => TheModelFactory.Create(x));
            return Ok(categories);
        }        
    }
}