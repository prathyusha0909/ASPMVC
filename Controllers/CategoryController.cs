using MvcApplication.Infrastructure;
using MvcApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication.Controllers
{
    public class CategoryController : Controller
    {
        IRepository<Category, int> repository;
        public CategoryController()
            {
               repository = new CategoryRepository();
            }
        // GET: Category
        public ActionResult Index()
        {
            var model = repository.GetAll();
            return View(model:model);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            var model = repository.GetDetails(identity: id);
            return View(model:model);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            var model = new Category();
            return View(model:model);
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                // TODO: Add insert logic here
               /* if(string.IsNullOrEmpty(category.CategoryName) ||
                    string.IsNullOrEmpty(category.Description))
                {
                    ModelState.AddModelError("CategoryName","Field is Required.");
                    return View(model: category);
                }
                else
                {
                    ModelState.AddModelError("CategoryName", ""); //Removes the message
                }*/
                if(ModelState.IsValid)
                {
                    repository.CreateNew(item: category);
                    return RedirectToAction("Index");

                }
                else
                {
                    return View(model: category);
                }
              
                repository.CreateNew(item: category);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model:category);
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            var model = repository.GetDetails(identity: id);
            return View(model:model);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    repository.Update(item: category);
                    return RedirectToAction("Index");

                }
                else
                {
                    return View(model: category);
                }

                
            }
            catch
            {
                return View(model:category);
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
           // var moel = repository.GetDetails(identity: id);
            return View();
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
