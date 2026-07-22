using Microsoft.Data.SqlClient;
using System.Data;
    
using Ejmmaa.Services.Interfaces;
using Ejmmaa.Models.DTOs;
using Ejmmaa.Models.ViewModels;
using Ejmmaa.Data;

namespace Ejmmaa.Services.Implementations
{
    public class SectionsService : ISectionsService
    {

        private readonly DbHelper _dbHelper; 
         private readonly Helper _helper;

        public SectionsService(DbHelper dbHelper, Helper helper)
        {
                 _dbHelper = dbHelper; 
                 _helper = helper;
        }

         public bool SaveSection(SectionDto  sectionDto)
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
