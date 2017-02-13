using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JamesAlcaraz.NlayeredAppDemo.Application.ApplicationServices.Interfaces;
using JamesAlcaraz.NlayeredAppDemo.Application.Dto;
using JamesAlcaraz.NlayeredAppDemo.Core.Entities;
using JamesAlcaraz.NlayeredAppDemo.Core.Repositories;
using JamesAlcaraz.NlayeredAppDemo.EntityFramework;

namespace JamesAlcaraz.NlayeredAppDemo.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductAppService _productAppService;

        public ProductsController(IRepository<Product, int> repository, 
            IApplicationDbContext applicationDbContext, 
            IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        public ActionResult Index()
        {
            var model = _productAppService.GetList();
            return View(model);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var product = _productAppService.Get(id ?? 0);
            
            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Description")] ProductCreateInput  productCreate)
        {
            if (ModelState.IsValid)
            {
                _productAppService.Create(productCreate);
                return RedirectToAction("Index");
            }
            return View(productCreate);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            var product = _productAppService.Get(id ?? 0);
            
            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description")] ProductUpdateInput product)
        {
            if (ModelState.IsValid)
            {
                _productAppService.Update(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public ActionResult Delete(int id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            var product = _productAppService.Get(id);

            if (product == null)
                return HttpNotFound();
            
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _productAppService.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
