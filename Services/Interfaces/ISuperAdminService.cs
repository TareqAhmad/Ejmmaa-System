
using Ejmmaa.Models.DTOs;
using Ejmmaa.Models.ViewModels;

namespace Ejmmaa.Services.Interfaces
{
    public interface ISuperAdminService
    {
        public UserInfo Login(LoginRequest loginRequest);
    }
}