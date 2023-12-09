using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TimeTableCalculation.Models;

namespace TimeTableCalculation.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        
    }
}