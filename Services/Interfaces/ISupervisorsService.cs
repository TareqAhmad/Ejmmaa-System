

using Ejmmaa.Models.DTOs;
using Ejmmaa.Models.ViewModels;

namespace Ejmmaa.Services.Interfaces
{
    public interface ISupervisorsService
    {
        public UserInfo Login(LoginRequest loginRequest);
    }
}