

using Ejmmaa.Models.DTOs;
using Ejmmaa.Models.ViewModels;

namespace Ejmmaa.Services.Interfaces
{
    public interface IVotersService
    {
        public UserInfo Login(LoginRequest loginRequest);
    }
}