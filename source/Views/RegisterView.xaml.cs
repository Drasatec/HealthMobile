﻿using DrasatHealthMobile.Helpers;
using DrasatHealthMobile.Models;
using DrasatHealthMobile.ViewModels;
using DrasatHealthMobile.Views.Templates;
using System.Windows.Input;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DrasatHealthMobile.Views;

public partial class RegisterView : ContentPage
{
    int length = 2;
    bool inputValied = true;
    private byte position = 1;
    private bool lastPosition = false;
    private DropdownMenuTemplate Temp = null;
    private bool IsAnyDropdownMenuOpened = false;
    private UserRegisterModel UserRegister = new UserRegisterModel();
    private RegisterViewModel vm;

    public RegisterView(RegisterViewModel loginViewModel)
    {
        BindingContext = loginViewModel;
        vm = (BindingContext as RegisterViewModel);
        InitializeComponent();
    }

    protected override bool OnBackButtonPressed()
    {
        if (IsAnyDropdownMenuOpened)
        {
            CollapseLast();
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
            btnSave.Text = "التالي";
        }
        HandelTextOfButtonSaveOrNext();
    }

    private async void DropdownMenuTemplate_Clicked(object sender, EventArgs e)
    {
        await CollapseLast();
        var template = sender as DropdownMenuTemplate;
        Temp = template;
        IsAnyDropdownMenuOpened = true;
    }

    private async void NextOrSaveButton_Clicked(object sender, EventArgs e)
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
            var result = await vm.SendUserRegister();
        }
        HandelTextOfButtonSaveOrNext();
    }

    // this method return false if one or more inputs in InValid
    private bool CheckDataIsValidAtSlide1()
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

    private bool CheckDataIsValidAtSlide2()
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
        }
        return inputValied;
    }

    private void HandelTextOfButtonSaveOrNext()
    {
        if (position == 2 && length == 2)
        {
            btnSave.Text = "حفظ";
            lastPosition = true;
        }
        else if (position == 3 && length == 3)
        {
            btnSave.Text = "حفظ";
            lastPosition = true;
        }
        else
        {
            btnSave.Text = "التالي";
            lastPosition = false;
        }
    }

    private async void ManContainer_Tapped(object sender, TappedEventArgs e)
    {
        await CollapseLast();
    }

    private async Task<bool> CollapseLast()
    {
        if (Temp != null)
        {
            Temp.Close();
            IsAnyDropdownMenuOpened = false;
            return await Task.FromResult(false);
        }
        return true;
    }

    private async void StepForward(View first, View last)
    {
        var ss = TranslationX;

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

        var res = await Task.WhenAll(firstT1, firstT2, lastT1, lastT2);

        //finale
        first.IsVisible = false;
        first.TranslationX = -100;
        last.IsVisible = true;
        last.TranslationX = 0;
    }

    private async void StepBack(View current, View previous)
    {
        var ss = TranslationX;

        //preparation
        previous.IsVisible = true;

        // execution
        var currentT1 = current.TranslateTo(100, 0);
        var currentT2 = current.FadeTo(0);

        var previousT1 = previous.TranslateTo(0, 0);
        var previousT2 = previous.FadeTo(1);

        var res = await Task.WhenAll(currentT1, currentT2, previousT1, previousT2);

        //finale
        current.IsVisible = false;
        current.TranslationX = 100;
        current.Opacity = 0;
    }


}