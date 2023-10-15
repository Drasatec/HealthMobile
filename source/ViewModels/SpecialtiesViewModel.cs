using DrasatHealthMobile.Models.MedicalSpecialty;
using DrasatHealthMobile.Services.PublicServices;
using CommunityToolkit.Mvvm.ComponentModel;
using DrasatHealthMobile.Helpers;
using System.Windows.Input;

namespace DrasatHealthMobile.ViewModels;

public class SpecialtiesViewModel : ObservableObject
{
    public SpecialtiesViewModel(IPublicService publicService)
    {
        Specialties = new List<SpecialtyModel>();
        SpecialtiesTemp = new List<SpecialtyModel>();
        this.publicService = publicService;
        GetAll();
    }

    public List<SpecialtyModel> Specialties { get; set; }
    public ICommand SearchBoxTypingCommand => new Command<string>(SearchBoxTyping);

    private List<SpecialtyModel> SpecialtiesTemp;
    private readonly IPublicService publicService;

    private async void SearchBoxTyping(string text)
    {
        await GetFromSearch(text);
    }

    private async void GetAll()
    {
        try
        {
            var queryParams = new Dictionary<string, object>
            {
                { "lang", Helper.Language},
                { "appearance","true"},
                { "status","active"},
            };
            var result = await publicService.GetAllSpecialtiesAsync("MedicalSpecialty/all", queryParams);
            Specialties = SpecialtiesTemp = result.Data;
            OnPropertyChanged(nameof(Specialties));
        }
        catch (Exception ex)
        {
            await Alerts.DisplayAlert(nameof(SpecialtiesViewModel), nameof(GetAll), ex.Message);
        }
    }

    private async Task GetFromSearch(string text)
    {
        try
        {
            if (string.IsNullOrEmpty(text))
            {
                Specialties = SpecialtiesTemp;
                OnPropertyChanged(nameof(Specialties));
                return;
            }
            var queryParams = new Dictionary<string, object>
                {
                    { "lang", Helper.Language },
                    { "searchTerm", text },
                };
            var result = await publicService.GetAllSpecialtiesAsync("MedicalSpecialty/search", queryParams);
            Specialties = result.Data;
            OnPropertyChanged(nameof(Specialties));
        }
        catch (Exception ex)
        {
            await Alerts.DisplayAlert(nameof(SpecialtiesViewModel), nameof(GetFromSearch), ex.Message);
        }
    }
}

