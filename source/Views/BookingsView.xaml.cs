using DrasatHealthMobile.Helpers;
using DrasatHealthMobile.Models;
using DrasatHealthMobile.Services.PublicServices;
using Microsoft.Maui.Controls;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
namespace DrasatHealthMobile.Views;

public partial class BookingsView : ContentPage
{
    private readonly IPublicService publicService;
    public BookingsView(IPublicService publicService)
    {
        InitializeComponent();
        previousSelection = tabs.Children[0] as Button;
        this.publicService = publicService;
        BindingContext = this;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        GetAllBookings("future");

    }
    public List<BookingModel> Bookings { get; set; }
    private bool isRefreshing = false;
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

    private async void VisibletyContentOfTabs(int param)
    {
        //var view = contentOfTabs.Children[param] as View;
        //view.IsVisible = true;
        //previousView.IsVisible = false;
        //previousView = view;
        //await Task.Delay(TimeSpan.FromSeconds(1));
        //activityIndicator.IsRunning = false;

        if (param == 0)
        {
            await GetAllBookings("future");
        }
        else if (param == 1)
            await GetAllBookings("past");

    }

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (collectionBookings.SelectedItem == null)
            return;
        var bookingMedel = collectionBookings.SelectedItem as BookingModel;
        var navigationParameter = new Dictionary<string, object>
        {
            { "bookingDetailsModel", bookingMedel },
            //{ "bookingId", result.Id }
        };

        await Shell.Current.GoToAsync("BookingDetailsView", navigationParameter);
        collectionBookings.SelectedItem = null;
    }

    async Task GetAllBookings(string time)
    {
        try
        {
            int patient = AppPreferences.GetUserId();
            if (patient < 0) return;

            activityIndicator.IsRunning = true;
            var queryParam = $"lang={Helper.Language}&patientId={patient}&bookingTime={time}";
            var result = await publicService.GetAllBookingsAsync("Booking", queryParam);
            if (result != null)
            {
                Bookings = result.Data;
                OnPropertyChanged(nameof(Bookings));
            }
        }
        catch (Exception ex)
        {
            await Helper.DisplayAlert(nameof(BookingsView), nameof(GetAllBookings), ex.Message);
        }
        activityIndicator.IsRunning = false;
    }
}