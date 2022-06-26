using Catalog.Business.Category;
using Catalog.Business.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(ILogger<CatalogController> logger)
        {
            _logger = logger;
        }


        [HttpGet(Name = "GetCatalog")]
        public ActionResult<IEnumerable<DTOCatalog>?> Get(int id)
        {
            try
            {
                if (id < 0)
                    return StatusCode(200, CatalogBusiness.GetAll());
                else
                    return StatusCode(200, CatalogBusiness.GetByID(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost(Name = "PostCatalog")]
        public ActionResult<DTOCatalog> Post(DTOCatalog cat)
        {
            try
            {
                DTOCatalog? category = CatalogBusiness.Create(cat);
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

        [HttpPatch(Name = "PatchCatalog")]
        public ActionResult<DTOCatalog> Patch(DTOCatalog cat)
        {
            try
            {
                DTOCatalog? category = CatalogBusiness.Update(cat);
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

        [HttpDelete(Name = "DeleteCatalog")]
        public ActionResult Delete(DTOCatalog cat)
        {
            try
            {
                if (CatalogBusiness.Delete(cat))
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
