namespace DrasatHealthMobile.Views;

public partial class HomeView : ContentPage
{
	public HomeView()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        //Navigation.PushAsync(new SearchView(),true);
        Shell.Current.GoToAsync("SearchView");
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("SpecialtiesView");
        //Navigation.PushAsync(new SpecialtiesView());
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
        Shell.Current.GoToAsync("BookingsView");
    }
}