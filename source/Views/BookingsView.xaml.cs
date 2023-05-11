using System.Text.RegularExpressions;
namespace DrasatHealthMobile.Views;

public partial class BookingsView : ContentPage
{
    public BookingsView()
    {
        InitializeComponent();
        previousSelection = tabs.Children[0] as Button;
        previousView = (contentOfTabs.Children[0] as ContentView);
    }

    private Button previousSelection;
    private void OnTabClicked(object sender, EventArgs e)
    {
        var currentSelection = sender as Button;
        if (currentSelection == previousSelection) return;
        var commandParam = Convert.ToInt16(currentSelection.CommandParameter);

        currentSelection.Style = (Style)App.Current.Resources["Checked"];
        previousSelection.Style = (Style)App.Current.Resources["Unchecked"];

        previousSelection = currentSelection;
        VisibletyContentOfTabs(commandParam);
    }

    ContentView previousView;
    private void VisibletyContentOfTabs(int param)
    {
        var view = contentOfTabs.Children[param] as ContentView;
        view.IsVisible = true;
        previousView.IsVisible = false;
        previousView = view;
    }
}