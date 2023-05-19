namespace DrasatHealthMobile.Views;

public partial class AddBookingView : ContentPage
{
	public AddBookingView()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("AddMemberView");
    }
}