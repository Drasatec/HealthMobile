using Microsoft.Maui.Controls;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
namespace DrasatHealthMobile.Views;

public partial class BookingsView : ContentPage
{
    public BookingsView()
    {
        InitializeComponent();
        previousSelection = tabs.Children[0] as Button;
        previousView = (contentOfTabs.Children[0] as View);
    }

    private Button previousSelection;
    private void OnTabClicked(object sender, EventArgs e)
    {
        activityIndicator.IsRunning = true;

        var currentSelection = sender as Button;
        if (currentSelection == previousSelection) return;
        var commandParam = Convert.ToInt16(currentSelection.CommandParameter);

        currentSelection.Style = (Style)App.Current.Resources["Checked"];
        previousSelection.Style = (Style)App.Current.Resources["Unchecked"];

        previousSelection = currentSelection;
        VisibletyContentOfTabs(commandParam);
    }


    View previousView;
    private async void VisibletyContentOfTabs(int param)
    {
        var view = contentOfTabs.Children[param] as View;
        view.IsVisible = true;

        previousView.IsVisible = false;
        previousView = view;
        await Task.Delay(TimeSpan.FromSeconds(1));

        activityIndicator.IsRunning = false;

    }
}