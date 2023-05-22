using CommunityToolkit.Maui.Behaviors;
using CommunityToolkit.Maui.Core;

namespace DrasatHealthMobile.Views;

public partial class HomeView : ContentPage
{
    //public double WidthImage { get; set; }
    public HomeView()
    {
        InitializeComponent();
        //WidthImage = this.Width - 20;

        var timer = Application.Current.Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromSeconds(3);
        timer.Tick += (s, e) => Scrol();
        timer.Start();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
#if ANDROID
        this.Behaviors.Add(new StatusBarBehavior
        {
            StatusBarColor = Color.FromArgb("#0070CD")
        });
#endif
    }
    int flag = 0;
    void Scrol()
    {
        try
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                myCollectionView.ScrollTo((flag + 1) % 4);
                flag++;
            });
        }
        catch (Exception)
        {
        }
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//specialties/SpecialtiesView");
    }

    private void Button_Clicked_2(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("DoctorDetailsView");
    }

    private void Button_Clicked_3(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("BookingByPatient");
    }
    private void Button_Clicked_4(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("BookingDetailsView");
    }
    private void Button_Clicked_5(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//bookings/BookingsView");
    }

    private void Button_Clicked_6(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//doctors/DoctorsView");
    }

    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        //var item = (List<string>)(sender as CollectionView).ItemsSource;
        //var index = item.IndexOf((string)e.CurrentSelection.FirstOrDefault());
        // indicatorView.Position = index;
    }


    private void CollectionView_Scrolled(object sender, ItemsViewScrolledEventArgs e)
    {
        var index = e.CenterItemIndex;
        indicatorView.Position = index;
    }

    private void GoToSearchView_Tapped(object sender, TappedEventArgs e)
    {
        Shell.Current.GoToAsync("SearchView");
    }

    private void GoToDoSomethingView(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("DoSomethingView");

    }

    private async void Button_Clicked_7(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("AddMemberView");
    }

    private async void Button_Clicked_8(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("MembersView");
    }

    private async void GoToNotificationsView(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("NotificationsView");
    }
}