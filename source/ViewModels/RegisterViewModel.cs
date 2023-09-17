
using CommunityToolkit.Mvvm.ComponentModel;
using DrasatHealthMobile.Helpers;
using DrasatHealthMobile.Models;
using DrasatHealthMobile.Services.PublicServices;
using System.Windows.Input;

namespace DrasatHealthMobile.ViewModels;
public class RegisterViewModel : ObservableObject
{
    private readonly IPublicService publicService;

    public List<DropdownMenuModel> HumanGenderNamesMenu { get; set; }

    public RegisterViewModel(IPublicService publicService)
    {
        this.publicService = publicService;
        GetHumanGenderNames();
    }
    public ICommand FullNameTypingCommand => new Command<string>(SearchBoxTyping);
    public ICommand GenderListCommand => new Command<DropdownMenuModel>(GenderListEx);


    private async void SearchBoxTyping(string gender)
    {
        var ss = gender;
        await Helper.DisplayAlert("sd", "sd", gender);
    }

    private void GenderListEx(DropdownMenuModel gender)
    {
        var ss = gender;
        //await Helper.DisplayAlert("sd", "sd", gender.Name);
    }

    private async void GetHumanGenderNames()
    {
        var queryParams = $"?lang={Helper.Language}";
           
        //queryParams.Add("specialtyId", "" as string ?? "");

        var result = await publicService.GetAllHumanGenderAsync("HumanGender/names", queryParams);
        HumanGenderNamesMenu  = new List<DropdownMenuModel>(result.Count);
        foreach (var resultItem in result)
        {
            var gender = new DropdownMenuModel()
            {
                Id = resultItem.Id,
                Name = resultItem.Name,
            };
            HumanGenderNamesMenu.Add(gender);
        }
        OnPropertyChanged(nameof(HumanGenderNamesMenu));
    }
}
