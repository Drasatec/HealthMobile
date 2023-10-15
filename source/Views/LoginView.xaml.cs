using DrasatHealthMobile.Helpers;
using DrasatHealthMobile.Languages;
using DrasatHealthMobile.Models;
using DrasatHealthMobile.Services.PublicServices;
using System.Globalization;

namespace DrasatHealthMobile.Views;

public partial class LoginView : ContentPage
{
    private readonly IPublicService publicService;

    public LoginView(IPublicService publicService)
    {
        InitializeComponent();
        BindingContext = this;
        this.publicService = publicService;
    }
    bool IsEmail = false;
    bool IsPhoneNumber = false;
    private async void BtnSubmit_Clicked(object sender, EventArgs e)
    {
        var valid = CheckDataIsValid();
        if (valid)
        {
            errorMessageLabel.Text = string.Empty;
            var user = new UserLogin()
            {
                Email = emailTemplate.Text,
                PhoneNumber = emailTemplate.Text,
                Password = passwordTemplate.Text,
            };
            if (IsEmail)
            {
                await SendUserLogin("PatientAuth/login-by-mail", user);
            }
            else if (IsPhoneNumber)
            {
                await SendUserLogin("PatientAuth/login-by-phone", user);
            }
            passwordTemplate.Text = string.Empty;
        }

    }
    private bool CheckDataIsValid()
    {
        var text = emailTemplate.Text;
        var pass = passwordTemplate.Text;
        bool valid;

        if (Helper.IsValidEmail(text))
        {
            emailTemplate.ValidStyle();
            IsEmail = true;
            valid = true;
        }
        else if (Helper.IsValidPhoneNumber(text))
        {
            emailTemplate.ValidStyle();
            IsPhoneNumber = true;
            valid = true;
        }
        else
        {
            emailTemplate.InValidStyle();
            valid = false;
        }

        if (string.IsNullOrWhiteSpace(passwordTemplate.Text) || pass.Length < 3)
        {
            passwordTemplate.InValidStyle();
            valid = false;
        }
        else passwordTemplate.ValidStyle();

        return valid;
    }
    private async void BtnGoToRegister_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("RegisterView", true);
    }

    public async Task<bool> SendUserLogin(string endpoint, UserLogin user)
    {
        //var user = new UserLogin();
        try
        {
            var responseUser = await publicService.PostUserLonginAsync(endpoint, user);
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
                    errorMessageLabel.Text = responseUser.Message;
                    await Alerts.ToastAlert(responseUser.Message);
                }
            }
            return false;
        }
        catch (Exception ex)
        {
            await Alerts.DisplayAlert(nameof(LoginView), nameof(SendUserLogin), ex.Message);
            return false;
        }
    }

    public LocalizationResourceManager LocalizationResourceManager => LocalizationResourceManager.Instance;

    private void Button_Clicked(object sender, EventArgs e)
    {
        //var switchToCulture = AppResources.Culture.TwoLetterISOLanguageName
        //    .Equals("ar", StringComparison.InvariantCultureIgnoreCase) ? new CultureInfo("en") : new CultureInfo("ar");

        var switchToCulture = new CultureInfo("en");

        LocalizationResourceManager.Instance.SetCulture(switchToCulture);
       // Application.Current.MainPage = new AppShell();//  NavigationPage(new HomeView());
       // Application.Current.UserAppTheme = AppTheme.Light;
    }
}