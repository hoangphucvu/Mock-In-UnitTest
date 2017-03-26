using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FizzBuzzMVC.Models;

namespace FizzBuzzMVC.Controllers
{
    public class HomeController : Controller
    {
        private Repository repository;

        public HomeController(Repository repository)
        {
            this.repository = repository;
        }

        public HomeController()
        {
            this.repository = new WorkingProductRepository();
        }
        public ViewResult Index()
        {
            var products = repository.GetAll();
            return View(products);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}