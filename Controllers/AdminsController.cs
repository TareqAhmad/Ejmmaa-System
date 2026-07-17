
using Microsoft.AspNetCore.Mvc;

namespace Ejmmaa.Controllers
{
    public class AdminsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Manage()
        {
            return View();
        }
    }
}