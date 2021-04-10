using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avr.ServisOtomasyonu.Web.Controllers
{
    public class ErrorController : Controller
    {
        [Route("/Error/HandleError/{code:int}")]
        public IActionResult HandleError(int code)
        {
            ViewData["ErrorMessage"] = $"Error occurred. The ErrorCode is: {code}";
            return RedirectToAction("Error404", "Error");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error404()
        {
            return View();
        }
    }
}
