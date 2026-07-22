
using Ejmmaa.Models.DTOs;
using Ejmmaa.Models.ViewModels;

namespace Ejmmaa.Services.Interfaces
{
    public interface IElectionsService
    {

          public ClanViewModel GetClanData(UserDto user); 
          public bool SaveClan(SectionDto  sectionDto); 

    }
}