using DrasatHealthMobile.Models;
using DrasatHealthMobile.Models.Doctors;
using DrasatHealthMobile.Models.MedicalSpecialty;
using DrasatHealthMobile.Services.RequestProvider;
using DrasatHealthMobile.Helpers;

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
}
