using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
using Webgentle.Bookstore.Models;

namespace Webgentle.Bookstore.Controllers
{
    public class HomeController : Controller
    {
        [ViewData]
        public string CustomProperty { get; set; }

        [ViewData]
        public string Title { get; set; } 
        public ViewResult Index()
        {
            ViewData["property1"] = "Svetik";
            Title = "Home";

            CustomProperty = "Custom value";

            return View();
        }

        public ViewResult AboutUs()
        {
            return View();
        }

        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
