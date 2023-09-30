using DrasatHealthMobile.ViewModels;

namespace DrasatHealthMobile.Views;

public partial class BookingDetailsView : ContentPage
{
	public BookingDetailsView(BookingDetailsViewModel bookingDetailsViewModel)
	{
		BindingContext = bookingDetailsViewModel;
		InitializeComponent();
	}
}