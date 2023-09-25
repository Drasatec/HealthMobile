using DrasatHealthMobile.Helpers;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;

namespace DrasatHealthMobile.Views;

public partial class ProfileView : ContentPage
{
    public ProfileView()
    {
        InitializeComponent();
    }

    protected override bool OnBackButtonPressed()
    {
        Helper.NavigationTo("///main");
        return true;
    }
    private void Button_Clicked(object sender, EventArgs e)
    {

    }
}