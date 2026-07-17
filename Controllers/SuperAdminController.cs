

using Microsoft.AspNetCore.Mvc;

namespace Ejmmaa.Controllers
{
    public class SuperAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }
    }
    
}