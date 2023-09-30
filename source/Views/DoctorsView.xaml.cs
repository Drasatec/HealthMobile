using DrasatHealthMobile.Helpers;
using DrasatHealthMobile.Models.Doctors;
using DrasatHealthMobile.ViewModels;

namespace DrasatHealthMobile.Views;
public partial class DoctorsView : ContentPage
{
   
    DoctorsViewModel vm;
    bool filterIsOpen = false;
    public DoctorsView(DoctorsViewModel doctorsViewModel)
    {
        BindingContext = doctorsViewModel;
        vm = (BindingContext as DoctorsViewModel);
        InitializeComponent();
    }

    protected override bool OnBackButtonPressed()
    {
        if (filterIsOpen)
        {
            _ = CloseFilterFrameAninmation();
            return true;
        }
        return base.OnBackButtonPressed();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        daysCollection.SelectedItem = null;
        degressCollection.SelectedItem = null;
        bothMaleFemaleCheckBox.IsChecked = false;
        maleCheckBox.IsChecked = false;
        femaleCheckBox.IsChecked = false;
        searchEntryTemplate.Text = string.Empty;
    }
    private async void ClViewDoctors_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ClViewDoctors.SelectedItem == null)
            return;
        var navigationParameter = new Dictionary<string, object>
        {
            { "doctorModel", (ClViewDoctors.SelectedItem as DoctorModel) }
        };

        await Shell.Current.GoToAsync(nameof(DoctorDetailsView), navigationParameter);
        ClViewDoctors.SelectedItem = null;
    }

    // Tapped and button events
    private void CollectionView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
    {
        // collection.ScrollTo(collection.);
        //VisualStateManager.GoToState(visualStack, "Invalid");
    }

    private async void OpenFiltrFrame(object sender, TappedEventArgs e)
    {
        try
        {
            filterIsOpen = true;
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
        await CloseFilterFrameAninmation();
    }

    private void BothMaleFemaleCheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (bothMaleFemaleCheckBox.IsChecked)
        {
            vm.Filter.GenderId = null;
            maleCheckBox.IsChecked = false;
            femaleCheckBox.IsChecked = false;
        }
    }

    private void MaleCheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (maleCheckBox.IsChecked)
        {
            vm.Filter.GenderId = 1;
            femaleCheckBox.IsChecked = false;
            bothMaleFemaleCheckBox.IsChecked = false;
        }
    }

    private void FemaleCheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (femaleCheckBox.IsChecked)
        {
            vm.Filter.GenderId = 2;
            maleCheckBox.IsChecked = false;
            bothMaleFemaleCheckBox.IsChecked = false;
        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        vm.Refresh();
        await CloseFilterFrameAninmation();
    }

    private async Task CloseFilterFrameAninmation()
    {
        filterIsOpen = false;
        await borderFilter.TranslateTo(0, 800, length: 500, easing: Easing.CubicInOut);
        borderFilter.IsVisible = false;
    }
}