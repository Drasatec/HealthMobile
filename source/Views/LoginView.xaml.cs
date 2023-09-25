using DrasatHealthMobile.Helpers;
using DrasatHealthMobile.Models;
using DrasatHealthMobile.Services.PublicServices;
using System.Diagnostics;

namespace DrasatHealthMobile.Views;

public partial class LoginView : ContentPage
{
    private readonly IPublicService publicService;

    public LoginView(IPublicService publicService)
    {
        InitializeComponent();
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
        var valid = false;

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

        var responseUser = await publicService.PostUserLonginAsync(endpoint, user);
        if (responseUser != null)
        {
            if (responseUser.Success)
            {
                Helper.SetValue("token", responseUser.Token);
                Helper.SetValue("userName", responseUser.UserAccount?.userName);
                Helper.SetValue<int>("userId", responseUser.UserAccount.userId);
                await Helper.NavigationToAsync("///main");
                Debug.WriteLine(responseUser.Token);
                await Helper.ToastAlert(responseUser.UserAccount.userId.ToString());

                return true;
            }
            else
            {
                errorMessageLabel.Text = responseUser.Message;
                await Helper.ToastAlert(responseUser.Message);
            }
        }
        return false;
    }
}