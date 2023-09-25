using DrasatHealthMobile.Models;
using DrasatHealthMobile.Models.Doctors;
using DrasatHealthMobile.Models.MedicalSpecialty;
using DrasatHealthMobile.Services.RequestProvider;
using DrasatHealthMobile.Helpers;
using DrasatHealthMobile.Models.Countries;
using DrasatHealthMobile.Models.UserModels;

namespace DrasatHealthMobile.Services.PublicServices;
public class PublicService : IPublicService
{
    public IRequestProvider RequestProvider { get; }

    public PublicService(IRequestProvider requestProvider)
    {
        RequestProvider = requestProvider;
    }

    public async Task<PagedResponse<SpecialtyModel>> GetAllSpecialtiesAsync(string endpoint, Dictionary<string, object> queryParams)
    {
        PagedResponse<SpecialtyModel> list;
        
        try
        {
            list = await RequestProvider.GetPagedResponseAsync<SpecialtyModel>($"{Constants.BaseUrl}{endpoint}{Helper.BuildQueryString(queryParams)}", "").ConfigureAwait(false);
        }
        catch (HttpRequestException exception) when (exception.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            list = null;
        }
        return list;
    }
    
    public async Task<PagedResponse<DoctorModel>> GetAllDoctorsAsync(string endpoint, Dictionary<string, string> queryParams)
    {
        PagedResponse<DoctorModel> list;
        
        try
        {
            list = await RequestProvider.GetPagedResponseAsync<DoctorModel>($"{Constants.BaseUrl}{endpoint}{await Helper.BuildQueryString(queryParams)}", "").ConfigureAwait(false);
        }
        catch (HttpRequestException exception) when (exception.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            list = null;
        }
        return list;
    }
    
    public async Task<List<HumanGenderNames>> GetAllHumanGenderAsync(string endpoint, string param)
    {
        List<HumanGenderNames> list;
        
        try
        {
            list = await RequestProvider.GetListAsync<HumanGenderNames>($"{Constants.BaseUrl}{endpoint}{param}", "").ConfigureAwait(false);
        }
        catch (HttpRequestException exception) when (exception.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            list = null;
        }
        return list;
    }
    
    public async Task<List<MaritalStatusNames>> GetAllMaritalStatusAsync(string endpoint, string param)
    {
        List<MaritalStatusNames> list;
        
        try
        {
            list = await RequestProvider.GetListAsync<MaritalStatusNames>($"{Constants.BaseUrl}{endpoint}{param}", "").ConfigureAwait(false);
        }
        catch (HttpRequestException exception) when (exception.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            list = null;
        }
        return list;
    }
    
    public async Task<string> GetConfirmationOptionAsync()
    {
        string text;
        try
        {
            text = await RequestProvider.GetStringAsync($"{Constants.BaseUrl}ConfirmationOption/option-chosen", "").ConfigureAwait(false);
        }
        catch (HttpRequestException exception) when (exception.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            text = null;
        }
        return text;
    }

    public async Task<PagedResponse<CountryModel>> GetAllCountriesAsync(string endpoint, string queryParams)
    {
        PagedResponse<CountryModel> list;

        try
        {
            list = await RequestProvider.GetPagedResponseAsync<CountryModel>($"{Constants.BaseUrl}{endpoint}?{queryParams}", "").ConfigureAwait(false);
        }
        catch (HttpRequestException exception) when (exception.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            list = null;
        }
        return list;
    }
    
    public async Task<UserRegisterResponse> PostUserRegisterAsync(string endpoint, UserRegisterModel user)
    {
        UserRegisterResponse response;

        try
        {
            response = await RequestProvider.PostSingleAsync<UserRegisterResponse, UserRegisterModel>($"{Constants.BaseUrl}{endpoint}",data:user).ConfigureAwait(false);
        }
        catch (HttpRequestException exception) when (exception.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            response = null;
        }
        return response;
    }
    
    public async Task<UserRegisterResponse> PostUserLonginAsync(string endpoint, UserLogin user)
    {
        UserRegisterResponse response;

        try
        {
            response = await RequestProvider.PostSingleAsync<UserRegisterResponse, UserLogin>($"{Constants.BaseUrl}{endpoint}",data:user).ConfigureAwait(false);
        }
        catch (HttpRequestException exception) when (exception.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            response = null;
        }
        return response;
    }

}
