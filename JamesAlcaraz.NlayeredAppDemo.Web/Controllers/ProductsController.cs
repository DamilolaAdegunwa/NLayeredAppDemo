using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JamesAlcaraz.NlayeredAppDemo.Core.Entities;
using JamesAlcaraz.NlayeredAppDemo.Core.Repositories;
using JamesAlcaraz.NlayeredAppDemo.EntityFramework;

namespace JamesAlcaraz.NlayeredAppDemo.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IRepository<Product, int> _repository;
        private readonly IEntitiesContext _entitiesContext;

        public ProductsController(IRepository<Product, int> repository, IEntitiesContext entitiesContext)
        {
            _repository = repository;
            _entitiesContext = entitiesContext;
        }

        public ActionResult Index()
        {
            return View(_repository.GetAll().ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _repository.FindById(id ?? 0);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description")] Product product)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(product);
                _entitiesContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _repository.FindById(id ?? 0);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description")] Product product)
        {
            if (ModelState.IsValid)
            {
                Product entity = _repository.FindById(product.Id);
                entity.Description = product.Description;
                _repository.Update(entity);
                _entitiesContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _repository.FindById(id??0);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = _repository.FindById(id);
            _repository.Delete(id);
            _entitiesContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
