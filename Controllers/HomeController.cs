using HealthCare_app.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HealthCare_app.Controllers
{
    public class HomeController : Controller
    {
        

        public async Task<IActionResult> Index()
        {

            // Render the main page view
            return View();
        }
    }
}