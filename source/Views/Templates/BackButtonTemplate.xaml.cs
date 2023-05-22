using System;

namespace DrasatHealthMobile.Views.Templates;

public partial class BackButtonTemplate : ContentView
{
    public BackButtonTemplate()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty TitleProperty = BindableProperty.Create(
        nameof(Title),
        typeof(string),
        typeof(BackButtonTemplate),
        "Title");
    
    public static readonly BindableProperty ButtonIsVisibleProperty = BindableProperty.Create(
        nameof(ButtonIsVisible),
        typeof(bool),
        typeof(BackButtonTemplate),
        true);

    public string Title
    {
        get { return (string)GetValue(TitleProperty); }
        set { SetValue(TitleProperty, value); }
    }
    
    public bool ButtonIsVisible
    {
        get { return (bool)GetValue(ButtonIsVisibleProperty); }
        set { SetValue(ButtonIsVisibleProperty, value); }
    }

    public void Refresh()
    {
        OnPropertyChanged(nameof(Title));
    }

    private void BackButton(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
        //Navigation.PopAsync(false);
        //App.Current.MainPage.DisplayAlert("title", "message", "cancel");
    }
    public async Task DDDD()
    {
        await Shell.Current.DisplayAlert("ddd","ddddd","sssssss");
    }
}