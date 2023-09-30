using DrasatHealthMobile.Models;
using DrasatHealthMobile.ViewModels;

namespace DrasatHealthMobile.Views;

public partial class AddBookingView : ContentPage
{
    public AddBookingView(AddBookingViewModel addBookingViewModel)
    {
        BindingContext = addBookingViewModel;
        InitializeComponent();
    }
}