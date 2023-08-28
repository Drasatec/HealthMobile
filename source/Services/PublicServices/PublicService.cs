using alrahmacare00.Models;
using alrahmacare00.Models.MedicalSpecialty;
using alrahmacare00.Services.RequestProvider;
using DrasatHealthMobile.Helpers;

namespace alrahmacare00.Services.PublicServices;
public class PublicService : IPublicService
{
    public IRequestProvider RequestProvider { get; }

    public PublicService(IRequestProvider requestProvider)
    {
        RequestProvider = requestProvider;
    }


    public async Task<PagedResponse<SpecialtyModel>> GetAllSpecialtiesAsync(string guidUser)
    {
        PagedResponse<SpecialtyModel> list;
        
        try
        {
            list = await RequestProvider.GetPagedResponseAsync<SpecialtyModel>($"{Constants.BaseUrl}MedicalSpecialty/all?lang={Hepler.Language}", "").ConfigureAwait(false);
        }
        catch (HttpRequestException exception) when (exception.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            list = null;
        }
        return list;
    }
}
