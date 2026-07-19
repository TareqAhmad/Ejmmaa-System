


using Microsoft.AspNetCore.Mvc;
using Ejmmaa.Models.DTOs;
using Ejmmaa.Services.Interfaces;
using Microsoft.AspNetCore.Http.Connections;
using Ejmmaa.Models.ViewModels;

namespace Ejmmaa.Controllers
{

    public class MembersController : Controller
    {

        public IActionResult Index()
        {
            return View(); 
        }


       public IActionResult Create()
        {
            return View(); 
        }

        public IActionResult Edit()
        {
            return View(); 
        }

        public IActionResult Delete()
        {
            return View(); 
        }


    }


}