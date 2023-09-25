using DrasatHealthMobile.Models;
using DrasatHealthMobile.Models.Countries;
using DrasatHealthMobile.Models.Doctors;
using DrasatHealthMobile.Models.MedicalSpecialty;
using DrasatHealthMobile.Models.UserModels;

namespace DrasatHealthMobile.Services.PublicServices;

public interface IPublicService
{
    Task<PagedResponse<CountryModel>> GetAllCountriesAsync(string endpoint, string queryParams);
    Task<PagedResponse<DoctorModel>> GetAllDoctorsAsync(string endpoint, Dictionary<string, string> queryParams);
    Task<List<HumanGenderNames>> GetAllHumanGenderAsync(string endpoint, string param);
    Task<List<MaritalStatusNames>> GetAllMaritalStatusAsync(string endpoint, string param);
    Task<PagedResponse<SpecialtyModel>> GetAllSpecialtiesAsync(string endpoint, Dictionary<string, object> queryParams);
    Task<string> GetConfirmationOptionAsync();
    Task<UserRegisterResponse> PostUserLonginAsync(string endpoint, UserLogin user);
    Task<UserRegisterResponse> PostUserRegisterAsync(string endpoint, UserRegisterModel user);
}
