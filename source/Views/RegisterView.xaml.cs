using DrasatHealthMobile.ViewModels;

namespace DrasatHealthMobile.Views;

public partial class RegisterView : ContentPage
{
	public RegisterView(RegisterViewModel loginViewModel)
	{
		BindingContext = loginViewModel;
		InitializeComponent();
	}
}