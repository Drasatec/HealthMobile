namespace DrasatHealthMobile.Views;

public partial class PrivacyPolicyView : ContentPage
{
	public PrivacyPolicyView()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync("..");
    }
}