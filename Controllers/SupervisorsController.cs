
using Microsoft.AspNetCore.Mvc;
using Ejmmaa.Models.DTOs;
using Ejmmaa.Services.Interfaces;

namespace Ejmmaa.Controllers
{
    public class SupervisorsController : Controller
    {
       private readonly ISupervisorsService _supervisorsService; 

       public SupervisorsController(ISupervisorsService supervisorsService)
        {
            _supervisorsService = supervisorsService; 
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Panel()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromBody]LoginRequest loginRequest)
        {
            if (loginRequest.UserName == null || loginRequest.Password == null)
            {
               return  Json(new { success = false, message = "اسم المستخدم أو كلمة المرور غير صحيحة." });
            }
              
           
            var userInfo = _supervisorsService.Login(loginRequest);
           
           if (userInfo == null)
            {
                return Json(new { success = false, message = "اسم المستخدم أو كلمة المرور غير صحيحة." });
            }

            return Json(new { success = true, data = userInfo, message = "تم تسجيل الدخول بنجاح." });
       
        }

    }
    
}