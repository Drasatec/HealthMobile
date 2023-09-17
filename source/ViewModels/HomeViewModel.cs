using DrasatHealthMobile.Models.Hospital;
using DrasatHealthMobile.Models.Promotion;
using DrasatHealthMobile.Services.Home;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DrasatHealthMobile.ViewModels;

public class HomeViewModel : ObservableObject
{
    private readonly IHomeServices homeServices;

    public List<PromotionModel> Promotions { get; set; }

    public List<string> ListOfServices { get; set; } = new List<string>()
    {
        "العيادات",
        "الخدمات",
        "الأطباء",
    };

    public HomeViewModel(IHomeServices homeServices)
    {
        this.homeServices = homeServices;
        Promotions = new List<PromotionModel>();

        GetNames();
    }

    public async void GetNames()
    {
        var result = await homeServices.GetPromotionModelAsync("");
        if (result == null)
        {
            return;
        }
        Promotions = result.Data;
        OnPropertyChanged(nameof(Promotions));
    }
}
