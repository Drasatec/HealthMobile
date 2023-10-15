using DrasatHealthMobile.Helpers;
using DrasatHealthMobile.Languages;
using DrasatHealthMobile.ViewModels;

namespace DrasatHealthMobile.Views;
public partial class DoctorDetailsView : ContentPage
{
    public DoctorDetailsView(DoctorDetailsViewModel viewmodel)
    {
        InitializeComponent();
        BindingContext = viewmodel;
    }

    int flag = 0;
    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        try
        {
            var uuu = (sender) as Label;
            if (flag == 0)
            {
                uuu.Text = AppResources.DoctorDetails_ReadLess;
                aboutLabel.MaxLines = default;
                aboutLabel.LineBreakMode = LineBreakMode.WordWrap;
                flag = 1;
            }
            else
            {
                uuu.Text = AppResources.DoctorDetails_ReadMore;
                aboutLabel.MaxLines = 3;
                aboutLabel.LineBreakMode = LineBreakMode.TailTruncation;
                flag = 0;
            }
        }
        catch (Exception ex)
        {
            await Alerts.DisplayAlert(nameof(DoctorDetailsView), nameof(TapGestureRecognizer_Tapped), ex.Message);
        }
    }
}