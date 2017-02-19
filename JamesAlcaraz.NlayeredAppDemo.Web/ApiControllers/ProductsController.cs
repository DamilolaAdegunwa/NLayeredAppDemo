using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JamesAlcaraz.NlayeredAppDemo.Application.ApplicationServices.Interfaces;
using JamesAlcaraz.NlayeredAppDemo.Application.Dto;
using JamesAlcaraz.NlayeredAppDemo.Core.Repositories.PagedList;

namespace JamesAlcaraz.NlayeredAppDemo.Web.ApiControllers
{
    public class ProductsController : ApiController
    {
        private readonly IProductAppService _productAppService;

        public ProductsController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        // GET: api/Products
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [Route("api/Products/page/{pageNumber}/pageSize/{pageSize}")]
        public IPagedList<ProductGridOutput> Get(int pageNumber, int pageSize)
        {
            return _productAppService.GetPagedList(pageNumber, pageSize);
        }

        // GET: api/Products/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Products
        public void Post([FromBody]string value)
        {
            var test = 0;
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
