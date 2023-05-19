using Microsoft.Maui.Controls;

namespace DrasatHealthMobile.Views;

public partial class DoctorsView : ContentPage
{
    public DoctorsView() => InitializeComponent();

    private async void ClViewDoctors_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ClViewDoctors.SelectedItem == null) return;
        await Shell.Current.GoToAsync("DoctorDetailsView");
        ClViewDoctors.SelectedItem = null;
    }


    private void CollectionView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
    {
        var collection = (CollectionView)sender;
        // collection.ScrollTo(collection.);
        //VisualStateManager.GoToState(visualStack, "Invalid");
    }
    private async void OpenFiltrFrame(object sender, TappedEventArgs e)
    {
        try
        {
            borderFilter.TranslationY = 800;
            borderFilter.IsVisible = true;
            await borderFilter.TranslateTo(0, 0, length: 500, easing: Easing.CubicInOut);
        }
        catch (Exception)
        {

        }
    }
    private async void CloseFiltrFrame(object sender, EventArgs e)
    {
        await borderFilter.TranslateTo(0, 800,length:500, easing: Easing.CubicInOut);
        borderFilter.IsVisible = false;
    }
}