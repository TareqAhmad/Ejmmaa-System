
using Ejmmaa.Models.DTOs;
using Ejmmaa.Models.ViewModels;

namespace Ejmmaa.Services.Interfaces
{
    public interface IAdminsService
    {
        public UserViewModel Login(LoginRequest loginRequest);
        public ClanViewModel GetClanData(UserDto user); 
        public List<ClanSectionsViewModel> GetClanSectionsData(UserDto user); 
        public List<ClanMembersViewModel> GetClanMembersData(UserDto user); 
    }
}