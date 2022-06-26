using Catalog.Business.Category;
using Catalog.Business.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger)
        {
            _logger = logger;
        }


        [HttpGet(Name = "GetCategory")]
        public ActionResult<IEnumerable<DTOCategory>?> Get(int id)
        {
            try
            {
                if (id < 0)
                    return StatusCode(200, CategoryBusiness.GetAll());
                else
                    return StatusCode(200, CategoryBusiness.GetByID(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost(Name = "PostCategory")]
        public ActionResult<DTOCategory> Post(DTOCategory cat)
        {
            try
            {
                DTOCategory? category = CategoryBusiness.Create(cat);
                if (category != null)
                    return StatusCode(201, category);
                else
                    return StatusCode(304, cat);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPatch(Name = "PatchCategory")]
        public ActionResult<DTOCategory> Patch(DTOCategory cat)
        {
            try
            {
                DTOCategory? category = CategoryBusiness.Update(cat);
                if (category != null)
                    return StatusCode(201, category);
                else
                    return StatusCode(304, cat);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete(Name = "DeleteCategory")]
        public ActionResult Delete(DTOCategory cat)
        {
            try
            {
                if (CategoryBusiness.Delete(cat))
                    return StatusCode(201);
                else
                    return StatusCode(304);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
