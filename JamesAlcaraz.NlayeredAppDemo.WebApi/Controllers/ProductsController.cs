using System.Web.Http;
using JamesAlcaraz.NlayeredAppDemo.Application.ApplicationServices.Interfaces;
using JamesAlcaraz.NlayeredAppDemo.Application.Dto.Products;

namespace JamesAlcaraz.NlayeredAppDemo.WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IProductAppService _productAppService;

        public ProductsController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        // GET: api/Products
        public IHttpActionResult Get()
        {
            var result = _productAppService.GetPagedList(1, 10);
            return Ok(result);
        }

        [Route("api/Products/page/{pageNumber:int}/pageSize/{pageSize:int}")]
        public IHttpActionResult Get(int pageNumber, int pageSize)
        {
            var result = _productAppService.GetPagedList(pageNumber, pageSize);
            return Ok(result);
        }

        // GET: api/Products/5
        [Authorize]
        public IHttpActionResult Get(int id)
        {
            var result = _productAppService.Get(id);
            if (result != null)
                return Ok(result);

            return NotFound();
        }

        // POST: api/Products
        public IHttpActionResult Post([FromBody]ProductCreateInput model)
        {
            var newProduct = _productAppService.Create(model);
            if (newProduct != null)
                return Created(Request.RequestUri + "/" + newProduct.Id.ToString(), newProduct);

            return Conflict();
        }

        // PUT: api/Products/5
        [AcceptVerbs("PUT", "POST")]
        public IHttpActionResult Put(int id, [FromBody]ProductUpdateInput model)
        {
            _productAppService.Update(model);
            return Ok();
        }

        // DELETE: api/Products/5
        public IHttpActionResult Delete(int id)
        {
            _productAppService.Delete(id);
            return Ok();
        }
    }
}
