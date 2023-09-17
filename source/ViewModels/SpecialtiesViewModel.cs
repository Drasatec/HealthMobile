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

    private void SearchBoxTyping(string text)
    {
        GetFromSearch(text);
    }

    private async void GetAll()
    {
        // Create query parameters
        var queryParams = new Dictionary<string, object>
            {
                { "lang", "ar" },
                { "page", "1" },
                { "pageSize", "10" },
            };
        var result = await publicService.GetAllSpecialtiesAsync("MedicalSpecialty/all", queryParams);
        Specialties = SpecialtiesTemp = result.Data;
        OnPropertyChanged(nameof(Specialties));
    }

    private async void GetFromSearch(string text)
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
                { "page", "" },
                { "pageSize", "" },
            };
        var result = await publicService.GetAllSpecialtiesAsync("MedicalSpecialty/search", queryParams);
        Specialties = result.Data;
        OnPropertyChanged(nameof(Specialties));
    }
}

