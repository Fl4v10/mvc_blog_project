using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCTutorialProject.Models;

namespace MVCTutorialProject.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Sobre")]
        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        [Route("Contato")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        [Route("{*url}")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
