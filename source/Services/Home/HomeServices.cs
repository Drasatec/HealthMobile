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
    public async Task<List<HospitalTranslation>> GetHosNamesAsync(string guidUser, string token)
    {
        //var uri = UriHelper.CombineUri(GlobalSetting.Instance.GatewayShoppingEndpoint, $"{ApiUrlBase}/{guidUser}");

        List<HospitalTranslation> hosTranc;

        try
        {
            hosTranc = await requestProvider.GetAsync<HospitalTranslation>("", token).ConfigureAwait(false);
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
        var lang = "ar";
        try
        {
            hosTranc = await requestProvider.GetPagedResponseAsync<PromotionModel>($"{Constants.BaseUrl}Promotion/all?lang={lang}", "").ConfigureAwait(false);
        }
        catch (HttpRequestException exception) when (exception.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            hosTranc = null;
        }
        return hosTranc;
    }
}
