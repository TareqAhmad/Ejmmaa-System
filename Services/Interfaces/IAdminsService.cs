
using Ejmmaa.Models.DTOs;
using Ejmmaa.Models.ViewModels;

namespace Ejmmaa.Services.Interfaces
{
    public interface IAdminsService
    {
        public UserInfo Login(LoginRequest loginRequest);
    }
}