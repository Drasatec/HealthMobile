using DrasatHealthMobile.Models;
using DrasatHealthMobile.Models.Doctors;
using DrasatHealthMobile.Models.MedicalSpecialty;

namespace DrasatHealthMobile.Services.PublicServices;

public interface IPublicService
{
    Task<PagedResponse<DoctorModel>> GetAllDoctorsAsync(string endpoint, Dictionary<string, string> queryParams);
    Task<List<HumanGenderNames>> GetAllHumanGenderAsync(string endpoint, string param);
    Task<PagedResponse<SpecialtyModel>> GetAllSpecialtiesAsync(string endpoint, Dictionary<string, object> queryParams);
}
