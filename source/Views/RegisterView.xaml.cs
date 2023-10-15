using DrasatHealthMobile.Helpers;
using DrasatHealthMobile.Languages;
using DrasatHealthMobile.ViewModels;
using DrasatHealthMobile.Views.Templates;
namespace DrasatHealthMobile.Views;

public partial class RegisterView : ContentPage
{
    int length = 2;
    bool inputValied = true;
    private byte position = 1;
    private bool lastPosition = false;
    private DropdownMenuTemplate Temp = null;
    private bool IsAnyDropdownMenuOpened = false;
    private readonly RegisterViewModel vm;

    public RegisterView(RegisterViewModel loginViewModel)
    {
        BindingContext = loginViewModel;
        vm = (BindingContext as RegisterViewModel);
        App.Current.UserAppTheme = AppTheme.Light;
        InitializeComponent();
    }

    protected override bool OnBackButtonPressed()
    {
        if (IsAnyDropdownMenuOpened)
        {
            _ = CollapseLast();
            return true;
        }
        return base.OnBackButtonPressed();
    }

    private void BackButton(object sender, EventArgs e)
    {
        if (position == 3)
        {
            StepBack(Slide3, Slide2);
            position--;
        }
        else if (position == 2)
        {
            StepBack(Slide2, Slide1);
            backToPreviousButton.IsVisible = false;
            position--;
            btnSave.Text = AppResources.Register_btn_Next;
        }
        HandelTextOfButtonSaveOrNext();
    }

    private async void DropdownMenuTemplate_Clicked(object sender, EventArgs e)
    {
        await CollapseLast();
        Temp = sender as DropdownMenuTemplate;
        IsAnyDropdownMenuOpened = true;
    }

    private async void NextOrSaveButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (position == 2)
            {
                CheckDataIsValidAtSlide2();
            }

            await CollapseLast();
            if (position == 1)
            {
                if (CheckDataIsValidAtSlide1())
                {
                    StepForward(Slide1, Slide2);
                    backToPreviousButton.IsVisible = true;
                    position++;
                }
            }
            else if (position == 2 && length > 2)
            {
                if (CheckDataIsValidAtSlide2())
                {
                    StepForward(Slide2, Slide3);
                    position++;
                }
            }
            //
            var s = vm.ConfirmationOptionChosen;
            length = (s == "email" || s == "sms") ? 3 : 2;

            if (lastPosition && inputValied)
            {
                await vm.SendUserRegister();
                passwordTemplate.Text = string.Empty;
                secondPassworddTemplate.Text = string.Empty;
            }
            HandelTextOfButtonSaveOrNext();
        }
        catch (Exception ex)
        {
            await Alerts.DisplayAlert(nameof(RegisterView), nameof(NextOrSaveButton_Clicked), ex.Message);
        }
    }

    // this method return false if one or more inputs in InValid
    private bool CheckDataIsValidAtSlide1()
    {
        try
        {
            var user = (BindingContext as RegisterViewModel).UserRegister;
            inputValied = true;
            if (user != null)
            {
                // if full Name is mistake Run Error Style and make inputValid flage == false 
                if (string.IsNullOrWhiteSpace(user.FullName))
                {
                    fullName.InValidStyle();
                    inputValied = false;
                }
                else { fullName.ValidStyle(); }
                //
                if (user.GenderId < 1)
                {
                    genderTemplate.InValidStyle();// = true;
                    inputValied = false;
                }
                else { genderTemplate.ValidStyle(); }
                //
                if (user.MaritalStatusId < 1)
                {
                    maritalStatusTemplate.InValidStyle();
                    inputValied = false;
                }
                else { maritalStatusTemplate.ValidStyle(); }
                //
                if (user.NationalityId < 1)
                {
                    countryTemplate.InValidStyle();
                    inputValied = false;
                }
                else { countryTemplate.ValidStyle(); }
            }
            return inputValied;
        }
        catch (Exception)
        {
            return inputValied;
        }
    }

    private bool CheckDataIsValidAtSlide2()
    {
        try
        {
            var user = (BindingContext as RegisterViewModel).UserRegister;
            inputValied = true;
            if (user != null)
            {
                // email
                if (!Helper.IsValidEmail(user.Email))
                {
                    emailTemplate.InValidStyle();
                    inputValied = false;
                }
                else { emailTemplate.ValidStyle(); }
                // CallingCode
                if (string.IsNullOrEmpty(user.CallingCode))
                {
                    callingCodeTemplate.InValidStyle();
                    inputValied = false;
                }
                else { callingCodeTemplate.ValidStyle(); }
                // PhoneNumber
                if (!Helper.IsValidPhoneNumber(user.PhoneNumber))
                {
                    phonNumberTemplate.InValidStyle();
                    if (!string.IsNullOrEmpty(user.PhoneNumber) && user.PhoneNumber[0] == '0')
                    {
                        // Remove the leading '0'
                        user.PhoneNumber = user.PhoneNumber.Substring(1);
                    }
                    inputValied = false;
                }
                else { phonNumberTemplate.ValidStyle(); }
                //ConfirmPassword
                if (!Helper.IsValidPhoneNumber(user.ConfirmPassword) || user.Password != user.ConfirmPassword)
                {
                    secondPassworddTemplate.InValidStyle();
                    inputValied = false;
                }
                else { secondPassworddTemplate.ValidStyle(); }
                //Password
                if (!Helper.IsValidPhoneNumber(user.Password))
                {
                    passwordTemplate.InValidStyle();
                    inputValied = false;
                }
                else { passwordTemplate.ValidStyle(); }
                //privacyCheckBox
                if (!privacyCheckBox.IsChecked)
                {
                    MustAgreePrivacy.Text = AppResources.Register_PrivacyMustAgree;
                    inputValied = false;
                }
                else { MustAgreePrivacy.Text = ""; }
            }
            return inputValied;
        }
        catch (Exception ex)
        {
            _ = Alerts.DisplayAlert(nameof(RegisterView), nameof(CheckDataIsValidAtSlide2), ex.Message);
            return inputValied;
        }
    }

    private void HandelTextOfButtonSaveOrNext()
    {
        try
        {
            if (position == 2 && length == 2)
            {
                btnSave.Text = AppResources.Register_btn_Save;
                lastPosition = true;
            }
            else if (position == 3 && length == 3)
            {
                btnSave.Text = AppResources.Register_btn_Save;
                lastPosition = true;
            }
            else
            {
                btnSave.Text = AppResources.Register_btn_Next;
                lastPosition = false;
            }
        }
        catch (Exception)
        {
        }

    }

    private async void MainContainer_Tapped(object sender, TappedEventArgs e)
    {
        await CollapseLast();
    }

    private async Task<bool> CollapseLast()
    {
        try
        {
            if (Temp != null)
            {
                Temp.Close();
                IsAnyDropdownMenuOpened = false;
                return await Task.FromResult(false);
            }
            return true;

        }
        catch (Exception)
        {
            return false;
        }
    }

    private static async void StepForward(View first, View last)
    {
        try
        {
            //preparation
            first.TranslationX = 0;
            first.Opacity = 1;
            first.IsVisible = true;
            last.Opacity = 0;
            last.TranslationX = 100;
            last.IsVisible = true;

            // execution
            var firstT1 = first.TranslateTo(-100, 0);
            var firstT2 = first.FadeTo(0);

            var lastT1 = last.TranslateTo(0, 0);
            var lastT2 = last.FadeTo(1);

            await Task.WhenAll(firstT1, firstT2, lastT1, lastT2);

            //finale
            first.IsVisible = false;
            first.TranslationX = -100;
            last.IsVisible = true;
            last.TranslationX = 0;
        }
        catch (Exception ex)
        {
            await Alerts.DisplayAlert(nameof(RegisterView), nameof(StepForward), ex.Message);
        }
    }

    private static async void StepBack(View current, View previous)
    {
        try
        {
            //preparation
            previous.IsVisible = true;

            // execution
            var currentT1 = current.TranslateTo(100, 0);
            var currentT2 = current.FadeTo(0);

            var previousT1 = previous.TranslateTo(0, 0);
            var previousT2 = previous.FadeTo(1);

            await Task.WhenAll(currentT1, currentT2, previousT1, previousT2);

            //finale
            current.IsVisible = false;
            current.TranslationX = 100;
            current.Opacity = 0;
        }
        catch (Exception ex)
        {
            await Alerts.DisplayAlert(nameof(RegisterView), nameof(StepBack), ex.Message);
        }
    }

    private void CheckPrivacy_Tapped(object sender, TappedEventArgs e)
    {
        Helpers.AppNavigations.GoTo("PrivacyPolicyView");
    }
}