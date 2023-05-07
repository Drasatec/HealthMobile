using System;

namespace DrasatHealthMobile.Views.Templates;

public partial class BackButtonTemplate : ContentView
{
    public BackButtonTemplate()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty PersonProperty = BindableProperty.Create(
        nameof(Title),
        typeof(string),
        typeof(string),
        "Title");

    public string Title
    {
        get { return (string)GetValue(PersonProperty); }
        set { SetValue(PersonProperty, value); }
    }

    public void Refresh()
    {
        OnPropertyChanged(nameof(Title));
    }


    private void BackButton(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
        Navigation.PopAsync(false);
        //App.Current.MainPage.DisplayAlert("title", "message", "cancel");
    }
}