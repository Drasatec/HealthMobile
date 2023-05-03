namespace DrasatHealthMobile.Views;

public partial class HomeView : ContentPage
{
	public HomeView()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new SearchView(),false);
    }
}