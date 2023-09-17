using DrasatHealthMobile.Helpers;
using DrasatHealthMobile.ViewModels;
using Microsoft.Maui.Controls;

namespace DrasatHealthMobile.Views;

//[QueryProperty(nameof(SpeId), "Id")]
public partial class DoctorsView : ContentPage
{
    int id;
    public int SpeId
    {
        get => id;
        set
        {
            id = value;
            OnPropertyChanged();
        }
    }

    public DoctorsView(DoctorsViewModel doctorsViewModel)
    {
        BindingContext = doctorsViewModel;
        InitializeComponent();
        var s = SpeId;
    }

    private async void ClViewDoctors_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ClViewDoctors.SelectedItem == null) return;
        //await Helper.DisplayAlert(nameof(DoctorsView),nameof(), "");
        await Helper.NavigationToAsync(nameof(DoctorDetailsView));
        //await Shell.Current.GoToAsync("DoctorDetailsView");
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
        await borderFilter.TranslateTo(0, 800, length: 500, easing: Easing.CubicInOut);
        borderFilter.IsVisible = false;
    }
}