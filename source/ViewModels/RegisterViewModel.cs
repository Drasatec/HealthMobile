using CommunityToolkit.Mvvm.ComponentModel;
using DrasatHealthMobile.Helpers;
using DrasatHealthMobile.Models;
using DrasatHealthMobile.Models.Countries;
using DrasatHealthMobile.Services.PublicServices;
using System.Windows.Input;
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
        _= GetHumanGenderNames();
        _= GetMaritalStatusNames();
        _=GetConfirmationOption();
        _=GetAllCountries();
    }

    // Commands ________________________________________________________
    public ICommand SelectionChangedGenderCommand => new Command<DropdownMenuModel>((DropdownMenuModel par) => UserRegister.GenderId = par.Id);
    public ICommand SelectionChangedMaritalStatusCommand => new Command<DropdownMenuModel>(SelectionChangedMaritalStatusExecute);
    public ICommand SelectionChangedCountryCommand => new Command<DropdownMenuModel>(SelectionChangedCountryExecute);
    public ICommand SelectionChangedCallingCodeCommand => new Command<DropdownMenuModel>(SelectionChangedCallingCodeExecute);

    // public Methods
    public async Task<bool> SendUserRegister()
    {
        try
        {
            UserRegister.LangCode = Helper.Language;
            var responseUser = await publicService.PostUserRegisterAsync("PatientAuth/reqister", UserRegister);
            if (responseUser != null)
            {
                if (responseUser.Success)
                {
                    AppPreferences.SetValue("token", responseUser.Token);
                    AppPreferences.SetValue("userName", responseUser.UserAccount?.userName);
                    AppPreferences.SetValue<int>("userId", responseUser.UserAccount.userId);
                    AppPreferences.SetValue("userEmail", responseUser.UserAccount.email);

                    AppNavigations.GoToMainPage();
                    return true;
                }
                else
                {
                    ErrorMessage = responseUser.Message;
                    await Alerts.ToastAlert(ErrorMessage);
                }
            }
            return false;
        }
        catch (Exception ex)
        {
            await Alerts.DisplayAlert(nameof(RegisterViewModel), nameof(SendUserRegister), ex.Message);
            return false;
        }
    }

    void SelectionChangedMaritalStatusExecute(DropdownMenuModel parameter)
    {
        UserRegister.MaritalStatusId = parameter.Id;
    }

    void SelectionChangedCountryExecute(DropdownMenuModel parameter)
    {
        UserRegister.NationalityId = parameter.Id;
    }

    async void SelectionChangedCallingCodeExecute(DropdownMenuModel parameter)
    {
        try
        {
            if (listOfCountries != null)
            {
                var callingCode = listOfCountries.FirstOrDefault(x => x.Id == parameter.Id).CallingCode;
                UserRegister.CallingCode = callingCode;
            }
        }
        catch (Exception ex)
        {
            await Alerts.DisplayAlert(nameof(RegisterViewModel), nameof(SelectionChangedCallingCodeExecute), ex.Message);
        }
    }

    // get data from a service
    private async Task GetHumanGenderNames()
    {
        try
        {
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
        catch (Exception ex)
        {
            await Alerts.DisplayAlert(nameof(RegisterViewModel), nameof(GetHumanGenderNames), ex.Message);
        }
    }

    private async Task GetMaritalStatusNames()
    {
        try
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
        catch (Exception ex)
        {
            await Alerts.DisplayAlert(nameof(RegisterViewModel), nameof(GetMaritalStatusNames), ex.Message);
        }
    }
    private async Task GetAllCountries()
    {
        var queryParams = $"lang={Helper.Language}";

        try
        {
            var result = await publicService.GetAllCountriesAsync("Country/all", queryParams);
            if (result != null && result.Data != null)
            {
                if (result.Data.Count > 0)
                {
                    listOfCountries = result.Data;
                    CountriesMenu = new List<DropdownMenuModel>(listOfCountries.Count);
                    CallingCodesMenu = new List<DropdownMenuModel>(listOfCountries.Count);
                    foreach (var resultItem in result.Data)
                    {
                        var country = new DropdownMenuModel()
                        {
                            Id = resultItem.Id,
                            Name = resultItem.CountriesTranslations.FirstOrDefault()?.CountryName,
                        };

                        var callingCode = new DropdownMenuModel()
                        {
                            Id = resultItem.Id,
                            Name = $"{resultItem.CountryCode} +{resultItem.CallingCode}"
                        };
                        CountriesMenu.Add(country);
                        CallingCodesMenu.Add(callingCode);
                        OnPropertyChanged(nameof(CountriesMenu));
                        OnPropertyChanged(nameof(CallingCodesMenu));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            await Alerts.DisplayAlert(nameof(RegisterViewModel), nameof(GetAllCountries), ex.Message);
        }
    }

    private async Task GetConfirmationOption()
    {
        try
        {
            ConfirmationOptionChosen = await publicService.GetConfirmationOptionAsync();
        }
        catch (Exception ex)
        {
            await Alerts.DisplayAlert(nameof(RegisterViewModel), nameof(GetConfirmationOption), ex.Message);
        }
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
