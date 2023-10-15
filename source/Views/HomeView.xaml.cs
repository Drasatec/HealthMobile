using DrasatHealthMobile.ViewModels;

namespace DrasatHealthMobile.Views;

public partial class HomeView : ContentPage
{
    int flag = 0;
    public HomeView(HomeViewModel homeViewModel)
    {
        BindingContext = homeViewModel;
        InitializeComponent();
        var timer = Application.Current.Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromSeconds(3);
        timer.Tick += (s, e) => Scrol();
        timer.Start();
    }

    void Scrol()
    {
        try
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                promotionCollectionView.ScrollTo((flag + 1) % 4);
                flag++;
            });
        }
        catch (Exception)
        {
        }
    }

    private void CollectionView_Scrolled(object sender, ItemsViewScrolledEventArgs e)
    {
        var index = e.CenterItemIndex;
        indicatorView.Position = index;
    }

    private async void GoToSearchView_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("///specialties");
    }

    private void GoToNotificationsView(object sender, TappedEventArgs e)
    {
        //await Shell.Current.GoToAsync("NotificationsView");
    }
    /*
     * #if ANDROID
            this.Behaviors.Add(new StatusBarBehavior
            {
                StatusBarColor = Color.FromArgb("#0070CD")
            });
       #endif
     */
}