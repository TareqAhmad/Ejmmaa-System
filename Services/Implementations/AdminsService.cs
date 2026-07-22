using Microsoft.Data.SqlClient;
using System.Data;
    
using Ejmmaa.Services.Interfaces;
using Ejmmaa.Models.DTOs;
using Ejmmaa.Models.ViewModels;
using Ejmmaa.Data;

namespace Ejmmaa.Services.Implementations
{
    public class AdminsService : IAdminsService
    {

        private readonly DbHelper _dbHelper; 
         private readonly Helper _helper;

        public AdminsService(DbHelper dbHelper, Helper helper)
            {
                 _dbHelper = dbHelper; 
                 _helper = helper;
            }


        public UserViewModel Login(LoginRequest loginRequest)
        {
            string passwordHash = _helper.ComputeMd5Hash(loginRequest.Password);
            
            string query = @"SELECT userId,FullName,TenantId,ClanId
                             FROM System_Users
                             WHERE UserName = @UserName 
                             AND PasswordHash = @Password";
            
            var parameters = new[]
            {
                new SqlParameter("@UserName", loginRequest.UserName),
                new SqlParameter("@Password", passwordHash)
            };

          DataTable dt = _dbHelper.Select(query,parameters);       
          
          if (dt.Rows.Count > 0)
          {  
              var row = dt.Rows[0];
              return new UserViewModel
              {
                  UserID = Convert.ToInt32(row["userId"]),
                  FullName = row["FullName"].ToString(),
                  TenantId = Convert.ToInt32(row["TenantId"]),
                  ClanId = Convert.ToInt32(row["ClanId"])
              };
          }

          throw new InvalidOperationException("Invalid username or password");
        }



       public List<ClanSectionsViewModel> GetClanSectionsData(UserDto user)
        {
            List<ClanSectionsViewModel> clanSections = new List<ClanSectionsViewModel>(); 
            
            string query = @"SELECT SectionId,SectionName
                            FROM Clan_Sections
                            WHERE ClanId = @ClanId"; 
            
            var parameters = new[]
            {
                new SqlParameter("@ClanId", user.ClanId),
            };               
            
         DataTable dt = _dbHelper.Select(query,parameters);       
          
        if (dt != null && dt.Rows.Count > 0)
            {  
                foreach (DataRow row in dt.Rows)
                {
                    var clanSection = new ClanSectionsViewModel
                    {
                        // تأكد أن أسماء الخصائص تطابق الـ ViewModel تماماً
                        SectionId = Convert.ToInt32(row["SectionId"]), 
                        SectionName = row["SectionName"].ToString()
                    };

                    clanSections.Add(clanSection); // حرف A كبير في Add
                }
            }

            return clanSections; 
        }
      
        public List<ClanMembersViewModel> GetClanMembersData(UserDto user)
        {
            List<ClanMembersViewModel> clanMembers = new List<ClanMembersViewModel>(); 
            
            string query = @"SELECT MemberId,fullName,NationalId,PhoneNumber,BirthDate,Gender
                            FROM Clan_Members
                            where ClanId = @ClanId"; 
            
            var parameters = new[]
            {
                new SqlParameter("@ClanId",user.ClanId),
            };               
            
         DataTable dt = _dbHelper.Select(query,parameters);       
          
        if (dt != null && dt.Rows.Count > 0)
            {  
                foreach (DataRow row in dt.Rows)
                {
                    var clanMember = new ClanMembersViewModel
                    {
                        // تأكد أن أسماء الخصائص تطابق الـ ViewModel تماماً
                        MemberId = Convert.ToInt32(row["MemberId"]), 
                        FullName = row["FullName"].ToString(),
                        NationalId =  row["NationalId"].ToString(),
                        PhoneNumber =  row["PhoneNumber"].ToString(),
                        BirthDate = Convert.ToDateTime(row["BirthDate"]),
                        Gender = Convert.ToChar(row["Gender"])
                    };

                    clanMembers.Add(clanMember); // حرف A كبير في Add
                }
            }

            return clanMembers; 
        }
   
   
   
    }
}