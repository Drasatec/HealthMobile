using DrasatHealthMobile.Models;
using DrasatHealthMobile.Models.Hospital;
using DrasatHealthMobile.Models.Promotion;
using DrasatHealthMobile.Services.RequestProvider;
using DrasatHealthMobile.Helpers;

namespace DrasatHealthMobile.Services.Home;

public class HomeServices : IHomeServices
{
    private readonly IRequestProvider requestProvider;

    public HomeServices(IRequestProvider requestProvider)
    {
        this.requestProvider = requestProvider;
    }
    public async Task<List<Models.Hospital.HospitalTranslation>> GetHosNamesAsync(string guidUser, string token)
    {
        //var uri = UriHelper.CombineUri(GlobalSetting.Instance.GatewayShoppingEndpoint, $"{ApiUrlBase}/{guidUser}");

        List<Models.Hospital.HospitalTranslation> hosTranc;

        try
        {
            hosTranc = await requestProvider.GetAsync<Models.Hospital.HospitalTranslation>("", token).ConfigureAwait(false);
        }
        catch (HttpRequestException exception) when (exception.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            hosTranc = null;
        }
        
        //_fixUriService.FixBasketItemPictureUri(basket?.Items);

        return hosTranc;
    }
    
    public async Task<PagedResponse<PromotionModel>> GetPromotionModelAsync(string guidUser)
    {
        PagedResponse<PromotionModel> hosTranc;
        try
        {
            hosTranc = await requestProvider.GetPagedResponseAsync<PromotionModel>($"{Constants.BaseUrl}Promotion/all?lang={Helper.Language}", "").ConfigureAwait(false);
        }
        catch (HttpRequestException exception) when (exception.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            hosTranc = null;
        }
        return hosTranc;
    }
}
