using DrasatHealthMobile.Helpers;
using DrasatHealthMobile.Models;
using DrasatHealthMobile.Services.PublicServices;
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
        _ = GetAllBookings("future");

    }
    protected override bool OnBackButtonPressed()
    {
        AppNavigations.GoToMainPage();
        return true;
    }
    public bool TimetableIsEmpty
    {
        get
        {
            if (Bookings != null && Bookings.Count > 0)
                return false;
            return true;
        }
    }
    public List<BookingModel> Bookings { get; set; }
    private Button previousSelection;
    private async void OnTabClicked(object sender, EventArgs e)
    {
        try
        {
            var currentSelection = sender as Button;
            if (currentSelection == previousSelection) return;
            var commandParam = Convert.ToInt16(currentSelection.CommandParameter);

            currentSelection.Style = (Style)App.Current.Resources["Checked"];
            previousSelection.Style = (Style)App.Current.Resources["Unchecked"];

            previousSelection = currentSelection;
            VisibletyContentOfTabs(commandParam);
        }
        catch (Exception ex)
        {
            await Alerts.DisplayAlert(nameof(BookingsView), nameof(OnTabClicked), ex.Message);
        }
    }

    private async void VisibletyContentOfTabs(int param)
    {
        if (param == 0)
        {
            await GetAllBookings("future");
        }
        else if (param == 1)
            await GetAllBookings("past");
    }

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            await Alerts.DisplayAlert(nameof(BookingsView), nameof(CollectionView_SelectionChanged), ex.Message);
        }
    }

    async Task GetAllBookings(string time)
    {
        try
        {
            int patient = AppPreferences.GetUserId();
            if (patient > 0)
            {
                activityIndicator.IsRunning = true;
                var queryParam = $"lang={Helper.Language}&patientId={patient}&bookingTime={time}";
                var result = await publicService.GetAllBookingsAsync("Booking", queryParam);
                if (result != null)
                {
                    Bookings = result.Data;
                }
            }
            else
                Bookings = null;
            OnPropertyChanged(nameof(Bookings));
            OnPropertyChanged(nameof(TimetableIsEmpty));
        }
        catch (Exception ex)
        {
            await Alerts.DisplayAlert(nameof(BookingsView), nameof(GetAllBookings), ex.Message);
        }
        activityIndicator.IsRunning = false;
    }
}