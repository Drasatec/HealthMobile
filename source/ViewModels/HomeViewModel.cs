using CommunityToolkit.Mvvm.ComponentModel;
using DrasatHealthMobile.Helpers;
using DrasatHealthMobile.Models.Promotion;
using DrasatHealthMobile.Services.Home;
namespace DrasatHealthMobile.ViewModels;

public class HomeViewModel : ObservableObject
{
    private readonly IHomeServices homeServices;

    public List<PromotionModel> Promotions { get; set; }

    public HomeViewModel(IHomeServices homeServices)
    {
        this.homeServices = homeServices;
        _ = GetNames();
    }

    public async Task GetNames()
    {
        try
        {
            var result = await homeServices.GetPromotionModelAsync("");
            if (result != null)
            {
                Promotions = result.Data;
                OnPropertyChanged(nameof(Promotions));
            }
        }
        catch (Exception ex)
        {
            await Alerts.DisplayAlert(nameof(HomeViewModel), nameof(GetNames), ex.Message);
        }

    }
}
