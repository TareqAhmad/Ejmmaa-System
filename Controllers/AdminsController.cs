
using Microsoft.AspNetCore.Mvc;
using Ejmmaa.Models.DTOs;
using Ejmmaa.Services.Interfaces;
using Microsoft.AspNetCore.Http.Connections;
using Ejmmaa.Models.ViewModels;

namespace Ejmmaa.Controllers
{

    public class AdminsController : Controller
    {

       private readonly IAdminsService _adminsService; 
       private readonly IClansService _clansService; 

       public AdminsController(IAdminsService adminsService,IClansService clansService)
        {
            _adminsService = adminsService; 
            _clansService = clansService; 
        }
        public IActionResult Index()
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
              
           
            var userInfo = _adminsService.Login(loginRequest);
           
           if (userInfo == null)
            {
                return Json(new { success = false, message = "اسم المستخدم أو كلمة المرور غير صحيحة." });
            }

            HttpContext.Session.SetInt32("UserId", userInfo.UserID);
            HttpContext.Session.SetString("FullName", userInfo.FullName);
            HttpContext.Session.SetInt32("TenantId",userInfo.TenantId); 
            HttpContext.Session.SetInt32("ClanId", userInfo.ClanId);

            return Json(new { success = true, data = userInfo, message = "تم تسجيل الدخول بنجاح." });
       
        }


       [SessionCheckFilter]
        public IActionResult Manage()
        {
            int? userId = HttpContext.Session.GetInt32("UserId"); 
            int? tenantId = HttpContext.Session.GetInt32("TenantId");
            int? clanId = HttpContext.Session.GetInt32("ClanId"); 


            var user = new UserDto {
                UserId = userId.Value,
                TenantId = tenantId.Value,
                ClanId = clanId.Value
            }; 

            var Clan = _clansService.GetClanData(user); 

            return View(Clan);
        }
        

       [SessionCheckFilter]
        public IActionResult GetClanSections()
        {

            int? clanId = HttpContext.Session.GetInt32("ClanId"); 

            var user = new UserDto {
                ClanId = clanId.Value
            }; 

            var ClanSections = _adminsService.GetClanSectionsData(user); 
             
            if(ClanSections == null) 
               return Json(new {success = false,message = "لا يوجد اقسام لهذه العشيرة"});

            return Json(new{success = true, data =  ClanSections});

        }

        [SessionCheckFilter]
        public IActionResult GetClanMembers()
        {

            int? clanId = HttpContext.Session.GetInt32("ClanId"); 

            var user = new UserDto {
                ClanId = clanId.Value
            }; 

            var ClanMembers = _adminsService.GetClanMembersData(user); 
             
            if(ClanMembers == null) 
               return Json(new {success = false,message = "لا يوجد افراد لهذه العشيرة"});

            return Json(new{success = true, data =  ClanMembers});

        }
    }
}