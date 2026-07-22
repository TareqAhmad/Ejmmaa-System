using Microsoft.Data.SqlClient;
using System.Data;
    
using Ejmmaa.Services.Interfaces;
using Ejmmaa.Models.DTOs;
using Ejmmaa.Models.ViewModels;
using Ejmmaa.Data;

namespace Ejmmaa.Services.Implementations
{
    public class ElectionsService : IElectionsService
    {

        private readonly DbHelper _dbHelper; 
         private readonly Helper _helper;

        public ElectionsService(DbHelper dbHelper, Helper helper)
        {
                 _dbHelper = dbHelper; 
                 _helper = helper;
        }
        public ClanViewModel GetClanData(UserDto user)
        {
            ClanViewModel clan = null; 

            string query  = @"SELECT ClanId,ClanName,CreatedAt
                              FROM Clans
                              WHERE ClanId = @ClanId
                              AND TenantId = @TenantId
                               AND IsActive = 1"; 

                              
            var parameters = new[]
            {
                new SqlParameter("@ClanId", user.ClanId),
                new SqlParameter("@TenantId", user.TenantId)
            };               
             
             
          DataTable dt = _dbHelper.Select(query,parameters);       
          
          if (dt.Rows.Count > 0)
          {  
              var row = dt.Rows[0];
              return new ClanViewModel
              {
                  ClanId  = Convert.ToInt32(row["ClanId"]),
                  ClanName = row["ClanName"].ToString(),
                  CreatedAt = Convert.ToDateTime(row["CreatedAt"]),

              };
          }

          throw new InvalidOperationException("Invalid username or password");


            
        } 
         public bool SaveClan(SectionDto  sectionDto)
        {
            string query  = @"INSERT INTO Clan_Sections(SectionName,ClanId)
                            VALUES(@SectionName,@ClanId)";
         
            var parameters = new[]
            {
                new SqlParameter("@SectionName", sectionDto.SectionName),
                new SqlParameter("@ClanId", sectionDto.ClanId)
            };


            int rowsAffected = _dbHelper.Execute(query, parameters);

            return rowsAffected > 0;
        }

    }
}
