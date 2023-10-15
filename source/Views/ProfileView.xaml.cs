using DrasatHealthMobile.Helpers;
using DrasatHealthMobile.Models;
using DrasatHealthMobile.Services.PublicServices;

namespace DrasatHealthMobile.Views;

public partial class ProfileView : ContentPage
{
    public ProfileView(IPublicService publicService)
    {
        InitializeComponent();
        this.publicService = publicService;
        GetPatienById();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        HandeLLoginButton();
    }
    public PatientModel Patient { get; set; }
    public string PatientEmail => AppPreferences.UserEmail;

    private readonly IPublicService publicService;

    protected override bool OnBackButtonPressed()
    {
        AppNavigations.GoToMainPage();
        return true;
    }
    private void Button_Clicked(object sender, EventArgs e)
    {

    }

    private async void GetPatienById()
    {
        try
        {
            var id = AppPreferences.GetUserId();
            if (id < 0) return;
            var queryParam = $"lang={Helper.Language}&id={id}";
            var result = await publicService.GetPatiendByIdAsync("Patient", queryParam);
            if (result != null)
            {
                Patient = result;
                OnPropertyChanged(nameof(Patient));
            }
            OnPropertyChanged(nameof(PatientEmail));
        }
        catch (Exception ex)
        {
            await Alerts.DisplayAlert(nameof(ProfileView), nameof(GetPatienById), ex.Message);
        }
    }

    private async void GoToSpecialties(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///specialties");
    }

    private async void GoToDoctors(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("DoctorsView");
    }

    private async void GoToBookings(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///bookings");
    }
    
    private async void GoToPrivacy(object sender, EventArgs e)
    {
       await Helpers.AppNavigations.GoToAsync("PrivacyPolicyView");
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        if (AppPreferences.IsLogin)
        {
            loginText.Text = Languages.AppResources.TabBar_logout;
            AppPreferences.ClearAll();
            Patient = null;

            HandeLLoginButton();
            //Shell.Current.GoToAsync("..");
            AppNavigations.GoToMainPage();

            //var stack = Shell.Current.Navigation.NavigationStack.LastOrDefault();
            //Shell.Current.Navigation.RemovePage(stack);
            //for (int i = stack.Length - 1; i > 0; i--)
            //{
            //}
        }
        else
        {
            AppNavigations.GoToLoginPage();
        }
    }

    void HandeLLoginButton()
    {
        if (AppPreferences.IsLogin)
        {
            loginText.Text = Languages.AppResources.TabBar_logout;
        }
        else
        {
            loginText.Text = Languages.AppResources.TabBar_login;

        }
        OnPropertyChanged(nameof(Patient));
        OnPropertyChanged(nameof(PatientEmail));
    }
}