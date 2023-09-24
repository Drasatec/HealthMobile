
using CommunityToolkit.Mvvm.ComponentModel;
using DrasatHealthMobile.Helpers;
using DrasatHealthMobile.Models;
using DrasatHealthMobile.Models.Countries;
using DrasatHealthMobile.Services.PublicServices;
using System.Diagnostics;
using System.Windows.Input;
using System.Xml.Linq;

namespace DrasatHealthMobile.ViewModels;
public class RegisterViewModel : ObservableObject
{
    public UserRegisterModel UserRegister { get; set; }
    public string ConfirmationOptionChosen { get; set; }
    public List<DropdownMenuModel> HumanGenderNamesMenu { get; set; }
    public List<DropdownMenuModel> MaritalStatusesNamesMenu { get; set; }
    public List<DropdownMenuModel> CountriesMenu { get; set; }
    public List<DropdownMenuModel> CallingCodesMenu { get; set; }

    // Constructor ________________________________________________________
    public RegisterViewModel(IPublicService publicService)
    {
        this.publicService = publicService;
        UserRegister = new UserRegisterModel();
        GetHumanGenderNames();
        GetMaritalStatusNames();
        GetConfirmationOption();
        GetAllCountries();
    }

    // Commands ________________________________________________________
    public ICommand SelectionChangedGenderCommand => new Command<DropdownMenuModel>((DropdownMenuModel par) => UserRegister.GenderId = par.Id);
    public ICommand SelectionChangedMaritalStatusCommand => new Command<DropdownMenuModel>(SelectionChangedMaritalStatusExecute);
    public ICommand SelectionChangedCountryCommand => new Command<DropdownMenuModel>(SelectionChangedCountryExecute);
    public ICommand SelectionChangedCallingCodeCommand => new Command<DropdownMenuModel>(SelectionChangedCallingCodeExecute);
    public ICommand ButtonNext => new Command(async () => await Helper.DisplayAlert("sd", "sd", ""));

    // public Methods
    public async Task<bool> SendUserRegister()
    {
        UserRegister.LangCode = Helper.Language;
        var responseUser = await publicService.PostUserRegisterAsync("PatientAuth/reqister", UserRegister);
        if (responseUser != null)
        {
            if (responseUser.Success)
            {
                Helper.SetValue("token", responseUser.Token);
                Helper.SetValue("userName", responseUser.UserAccount?.userName);
                await Helper.NavigationToAsync("///main");
                Debug.WriteLine(responseUser.Token);
                return true;
            }
            else
            {
                ErrorMessage = responseUser.Message;
                await Helper.ToastAlert(ErrorMessage);
            }
        }
        return false;
    }


    void SelectionChangedGenderExecute(DropdownMenuModel parameter)
    {
        UserRegister.GenderId = parameter.Id;
        var rrr = new UserRegisterModel()
        {
            FullName = "moooooooo",
            Email = "m1@yahoo.com",
            Password = "1234",
            PhoneNumber = "1254125478",
            CallingCode = "20",
            LangCode = "en",
            PhoneNumberConfirmed = true,
            EmailConfirmed = true,
            MaritalStatusId = 1,
            GenderId = 1,
            NationalityId = 1,
        };
    }

    void SelectionChangedMaritalStatusExecute(DropdownMenuModel parameter)
    {
        UserRegister.MaritalStatusId = parameter.Id;
    }

    void SelectionChangedCountryExecute(DropdownMenuModel parameter)
    {
        UserRegister.NationalityId = parameter.Id;
    }

    void SelectionChangedCallingCodeExecute(DropdownMenuModel parameter)
    {
        if (listOfCountries != null)
        {
            var callingCode = listOfCountries.FirstOrDefault(x => x.Id == parameter.Id).CallingCode;
            UserRegister.CallingCode = callingCode;
        }
    }

    // get data from a service
    private async void GetHumanGenderNames()
    {
        //await Task.Delay(9000);
        var queryParams = $"?lang={Helper.Language}";
        var result = await publicService.GetAllHumanGenderAsync("HumanGender/names", queryParams);
        if (result != null)
        {
            HumanGenderNamesMenu = new List<DropdownMenuModel>(result.Count);
            foreach (var resultItem in result)
            {
                var gender = new DropdownMenuModel()
                {
                    Id = resultItem.GenderId,
                    Name = resultItem.Name,
                };
                HumanGenderNamesMenu.Add(gender);
            }
            OnPropertyChanged(nameof(HumanGenderNamesMenu));
        }
    }
    private async void GetMaritalStatusNames()
    {
        var queryParams = $"?lang={Helper.Language}";

        var result = await publicService.GetAllMaritalStatusAsync("MaritalStatus/names", queryParams);
        MaritalStatusesNamesMenu = new List<DropdownMenuModel>(result.Count);
        foreach (var resultItem in result)
        {
            var gender = new DropdownMenuModel()
            {
                Id = resultItem.MaritalId,
                Name = resultItem.Name,
            };
            MaritalStatusesNamesMenu.Add(gender);
        }
        OnPropertyChanged(nameof(MaritalStatusesNamesMenu));
    }
    private async void GetAllCountries()
    {
        var queryParams = $"lang={Helper.Language}";

        var result = await publicService.GetAllCountriesAsync("Country/all", queryParams);
        if (result != null && result.Data != null)
        {
            listOfCountries = result.Data;
            CountriesMenu = new List<DropdownMenuModel>(result.Total);
            CallingCodesMenu = new List<DropdownMenuModel>(result.Total);
            foreach (var resultItem in result.Data)
            {
                var country = new DropdownMenuModel()
                {
                    Id = resultItem.Id,
                    Name = resultItem.CountriesTranslations[0]?.CountryName,
                };

                var callingCode = new DropdownMenuModel()
                {
                    Id = resultItem.Id,
                    Name = $"{resultItem.CountryCode} +{resultItem.CallingCode}"
                };
                CountriesMenu.Add(country);
                CallingCodesMenu.Add(callingCode);
            }
            OnPropertyChanged(nameof(CountriesMenu));
            OnPropertyChanged(nameof(CallingCodesMenu));
        }
    }
    private async void GetConfirmationOption()
    {
        ConfirmationOptionChosen = await publicService.GetConfirmationOptionAsync();
    }

    // 
    private readonly IPublicService publicService;
    private List<CountryModel> listOfCountries;
    // Properties  with Notification  ________________________________________________________
    string errorMessage = string.Empty;
    public string ErrorMessage
    {
        get => errorMessage;
        set => SetProperty(ref errorMessage, value);
    }
}
