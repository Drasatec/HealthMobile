using DrasatHealthMobile.Models.Doctors;
using DrasatHealthMobile.ViewModels;
using System.Reflection.Metadata;

namespace DrasatHealthMobile.Views;
//[QueryProperty(nameof(DoctorDetails), "doctorModel")]
public partial class DoctorDetailsView : ContentPage
{
    public DoctorDetailsView(DoctorDetailsViewModel viewmodel)
    {
        InitializeComponent();
        BindingContext = viewmodel;
    }

    //private DoctorModel doctorDetails;
    //public DoctorModel DoctorDetails
    //{
    //    get => doctorDetails;
    //    set
    //    {
    //        doctorDetails = value;
    //        OnPropertyChanged(nameof(DoctorDetails));
    //    }
    //}

    private void Button_Clicked(object sender, EventArgs e)
    {

    }
    int flag = 0;
    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        var uuu = (sender) as Label;
        if (flag == 0)
        {
            uuu.Text = "أقل";
            aboutLabel.MaxLines = default;
            aboutLabel.LineBreakMode = LineBreakMode.WordWrap;
            flag = 1;
        }
        else
        {
            uuu.Text = "قراءة المزيد";
            aboutLabel.MaxLines = 3;
            aboutLabel.LineBreakMode = LineBreakMode.TailTruncation;
            flag = 0;
        }
    }
    // deleted
    private async void BtnBookingClicked(object sender, EventArgs e)
    {
        try
        {
            var btn = sender as Button;
            var parameter = btn.CommandParameter;
            //await Shell.Current.GoToAsync("BookingDetailsView");
            var navigationParameter = new Dictionary<string, object>
            {
                { "docWPFromDocDetailsView", parameter }
            };
            await Shell.Current.GoToAsync("AddBookingView", navigationParameter);
        }
        catch (Exception ex)
        {
            await Helpers.Helper.DisplayAlert(nameof(AddBookingView), nameof(BtnBookingClicked), ex.Message);

        }
    }
}