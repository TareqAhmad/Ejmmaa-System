using Microsoft.Data.SqlClient;
using System.Data;
    
using Ejmmaa.Services.Interfaces;
using Ejmmaa.Models.DTOs;
using Ejmmaa.Models.ViewModels;
using Ejmmaa.Data;

namespace Ejmmaa.Services.Implementations
{
    public class MembersService : IMembersService
    {

        private readonly DbHelper _dbHelper; 
         private readonly Helper _helper;

        public MembersService(DbHelper dbHelper, Helper helper)
        {
                 _dbHelper = dbHelper; 
                 _helper = helper;
        }


        public bool SaveMember(MemberDto memberDto)
        {
            string query = @"INSERT INTO Clan_Members (FullName, NationalId, PhoneNumber, SectionId, BirthDate, ClanId) 
                     VALUES (@FullName, @NationalId, @PhoneNumber,@SectionId, @BirthDate, @ClanId)";

            var parameters = new[]
            {
                new SqlParameter("@FullName", memberDto.FullName),
                new SqlParameter("@NationalId", memberDto.NationalId),
                new SqlParameter("@PhoneNumber", memberDto.PhoneNumber),
                new SqlParameter("@SectionId", memberDto.SectionId),
                new SqlParameter("@BirthDate", (object)memberDto.BirthDate ?? DBNull.Value), // لحماية التاريخ إذا كان فارغاً
                new SqlParameter("@ClanId", memberDto.ClanId)
            };

            // افترض أن _dbHelper.Execute تعيد عدد الصفوف المتأثرة أو true/false عند النجاح
            int rowsAffected = _dbHelper.Execute(query, parameters);

            return rowsAffected > 0;
        }

    }
}
