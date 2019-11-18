using MvcApplication.Infrastructure;
using MvcApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication.Controllers
{
    public class HomeController : Controller
    {
        //Home/today
        public string Today()
        {
            return DateTime.Now.ToString();
        }
        //Home/Details
        public JsonResult Details()
        {
            var obj = new { Id = 12345, Name = "Canarys", Location = "Bengaluru" };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        CategoryRepository categoryRepository = new CategoryRepository();
        NorthwindContext productDb = new NorthwindContext();

      //  [HandleError(ExceptionType =typeof(Exception), View ="Error")]
        public ActionResult Index()
        {
            throw new Exception("Something went wrong!");
            /*var model = new CategoryProductViewModel
            {
                Categories = categoryRepository.GetAll().ToList(),
                Products = productDb.Products.ToList(),
                SelectedCategoryId = 0,
            SelectedCategoryName = string.Empty
            };
            return View(model);*/
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            var id =Convert.ToInt32("0" + collection["SelectedCategoryId"]);
            var products = productDb.Products.ToList();
            var categories = categoryRepository.GetAll();
            var selectedCategory = categories.FirstOrDefault(c => c.CategoryId == id);
            var matchingProducts = products.Where(c => c.CategoryId == selectedCategory.CategoryId);
            var model = new CategoryProductViewModel
            {
                Categories = categories.ToList(),
                Products = matchingProducts.ToList(),
                SelectedCategoryId = selectedCategory.CategoryId,
                SelectedCategoryName = selectedCategory.CategoryName
            };
            return View(model);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Route("home/customers/country/{country}")]//attribute routing

        public ActionResult GetCustomersByCountry(string country)
        {
            ViewBag.Message = "Customers By Country Page based in ." +country;

            return View("Contact");
        }
        [Route("home/about-us/{option}")]
        public ActionResult AboutUs(int option)
        {
            ViewData["one"] = "This is about action->two";
            ViewBag.one = "This is from About-Us Action->three";
          
            ViewData["ViewDataMessage"] = "This is from AboutUs Action->ViewDataMessage";
            ViewBag.ViewBagMessage = "This is from About-Us Action->ViewBagMessage";
            TempData["TempDataMessage"] = "This is from About-Us Action->TempDataMessage";
            Session["SessionMessage"] = "This is from About-Us Action->SessionMessage";
            if (option == 0)
            {
                return View();

            }
            else
                return RedirectToAction("AnotherAboutUs");
        }
        [Route("home/another-about-us")]
        public ActionResult AnotherAboutUs()
        {
            return View();
        }
    }
}