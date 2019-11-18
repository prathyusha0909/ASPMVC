using MvcApplication.Infrastructure;
using MvcApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication.Controllers
{
   // [Authorize] //can be used on the controller or action methods.
    public class CustomerController : Controller
    {
        IRepository<Customer, string> repository;

        public CustomerController()
        {
            repository = new CustomerRepository();
        }
        // GET: Customer
        public ActionResult Index()
        {
            var model = repository.GetAll(); //Get all the cusstomers and store it to model
            return View(model:model);  //Pass the model to the View
        }
        public ActionResult Details(string id)
        {
            var model = repository.GetDetails(identity: id);
            if (model != null)
                return View(model);
            else
                return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult Edit(string id)
        {
            var model = repository.GetDetails(identity: id);
            if (model != null)
                return View(model: model);
            else
                return RedirectToAction("Index");
        }
        [HttpPost]
       // public ActionResult Edit(FormCollection theForm)
       public ActionResult Edit(Customer model)
        {
            //string id = Request.Form["CustomerId"];
            //string company = Request.Form["CompanyName"];
            //string contact = Request.Form["contactName"];
            //string city = Request.Form["City"];
            //string country = Request.Form["Country"];

            //string id = theForm["CustomerId"];
            //string company = theForm["CompanyName"];
            //string contact = theForm["contactName"];
            //string city = theForm["City"];
            //string country = theForm["Country"];

            ////validate the data
            ////create the Model Entity
            //Customer model = new Customer
            //{
            //    CustomerId = id,
            //    CompanyName = company,
            //    ContactName = contact,
            //    City = city,
            //    Country = country
            //};
            repository.Update(model);//throws NotImplementedException currently
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {
            var model = new Customer();
            return View(model: model);
        }
        [HttpPost]
        public ActionResult Create(Customer model)
        {
            repository.CreateNew(model);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(string id)
        {
            var model = repository.GetDetails(identity: id);
            return View(model: model);

        }
        [HttpPost]
        public ActionResult DeleteConform(string id)
        {
            repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}