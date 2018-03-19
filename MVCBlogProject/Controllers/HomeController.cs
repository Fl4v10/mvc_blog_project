using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCBlog.App.Services;
using MVCBlog.Domain.Entities;
using MVCBlog.Models;

namespace MVCBlog.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return RedirectToAction("Home");
        }

        [HttpGet]
        [Route("Home")]
        public IActionResult Home(int? id, int? last, string search, BlogApp app)
        {
            List<Essay> model = app.Get(id, last, search);
            return View(model);
        }

        [HttpGet]
        [Route("About")]
        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        [Route("Contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        [Route("Publisher")]
        public IActionResult Publisher()
        {
            return View();
        }

        [HttpPost]
        [Route("Publisher")]
        public IActionResult Publisher(Essay model, BlogApp app)
        {
            int valid = app.Save(model);

            if (valid == 0)
                return RedirectToAction("Error");
            
            return RedirectToAction("Home");
        }

        [HttpGet]
        [Route("{*url}")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
