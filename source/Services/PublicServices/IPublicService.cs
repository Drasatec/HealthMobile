using DrasatHealthMobile.Models;
using DrasatHealthMobile.Models.Countries;
using DrasatHealthMobile.Models.Doctors;
using DrasatHealthMobile.Models.MedicalSpecialty;
using DrasatHealthMobile.Models.UserModels;

namespace DrasatHealthMobile.Services.PublicServices;

public interface IPublicService
{
    Task<Response> CancelBooning(string endpoint, string param);
    Task<PagedResponse<BookingModel>> GetAllBookingsAsync(string endpoint, string queryParams);
    Task<PagedResponse<CountryModel>> GetAllCountriesAsync(string endpoint, string queryParams);
    Task<PagedResponse<DoctorModel>> GetAllDoctorsAsync(string endpoint, Dictionary<string, string> queryParams);
    Task<List<DoctorsDegree>> GetAllDoctorsDegreesAsync(string endpoint, string param);
    Task<List<DoctorVisitPriceModel>> GetAllDoctorVisitPriceAsync(string endpoint, string param);
    Task<List<DoctorWorkPeriodModel>> GetAllDoctorWorkPeriodAsync(string endpoint, Dictionary<string, string> queryParams);
    Task<List<HospitalTranslation>> GetAllHospitalsTranslationsAsync(string endpoint, string param);
    Task<List<HumanGenderNames>> GetAllHumanGenderAsync(string endpoint, string param);
    Task<List<MaritalStatusNames>> GetAllMaritalStatusAsync(string endpoint, string param);
    Task<PagedResponse<SpecialtyModel>> GetAllSpecialtiesAsync(string endpoint, Dictionary<string, object> queryParams);
    Task<List<TypesVisitTranslation>> GetAllTypesVisitTranslationsAsync(string endpoint, string param);
    Task<List<Weekday>> GetAllWeekdaysAsync(string endpoint, string param);
    Task<BookingModel> GetBookingByIdAsync(string endpoint, string param);
    Task<string> GetConfirmationOptionAsync();
    Task<PatientModel> GetPatiendByIdAsync(string endpoint, string param);
    Task<ResponseWithId> PostBookingAsync(string endpoint, SendBookingModel user);
    Task<UserRegisterResponse> PostUserLonginAsync(string endpoint, UserLogin user);
    Task<UserRegisterResponse> PostUserRegisterAsync(string endpoint, UserRegisterModel user);
}
