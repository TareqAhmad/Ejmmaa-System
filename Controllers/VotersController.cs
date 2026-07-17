
using Microsoft.AspNetCore.Mvc;

namespace Ejmmaa.Controllers
{
    public class VotersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult VoterBallot()
        {
            return View();
        }
    }
}