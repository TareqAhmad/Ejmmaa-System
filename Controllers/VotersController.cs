
using Microsoft.AspNetCore.Mvc;
using Ejmmaa.Services.Interfaces;
using Ejmmaa.Models.DTOs;


namespace Ejmmaa.Controllers
{
    public class VotersController : Controller
    {

     private readonly IVotersService _votersService; 

       public VotersController(IVotersService votersService)
        {
            _votersService = votersService; 
        }
        
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult VoterBallot()
        {
            return View();
        }

                [HttpPost]
        public IActionResult Login([FromBody]LoginRequest loginRequest)
        {
            if (loginRequest.userName == null || loginRequest.password == null)
            {
               return  Json(new { success = false, message = "اسم المستخدم أو كلمة المرور غير صحيحة." });
            }
              
           
            var userInfo = _votersService.Login(loginRequest);
           
           if (userInfo == null)
            {
                return Json(new { success = false, message = "اسم المستخدم أو كلمة المرور غير صحيحة." });
            }

            return Json(new { success = true, data = userInfo, message = "تم تسجيل الدخول بنجاح." });
       
        }

    }
    
}