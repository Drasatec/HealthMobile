namespace DrasatHealthMobile.Views;

public partial class SearchView : ContentPage
{
    public SearchView()
    {
        InitializeComponent();
    }

    private void ButtonSpecialist_Clicked(object sender, EventArgs e)
    {
        buttonSpecialist.Style = (Style)App.Current.Resources["Checked"];
        buttonDoctor.Style = (Style)App.Current.Resources["Unchecked"];
        listOfDoctors.IsVisible = false;
        //StackResultFromSearch.Add(new Templates.BackButtonTemplate());
    }
    private void ButtonDoctor_Clicked(object sender, EventArgs e)
    {

        buttonDoctor.Style = (Style)App.Current.Resources["Checked"];

        buttonSpecialist.Style = (Style)App.Current.Resources["Unchecked"];
        listOfDoctors.IsVisible = true;
        //StackResultFromSearch.Add(new Templates.BackButtonTemplate());
    }

    private async void ClViewDoctors_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var collectionView = sender as CollectionView;
        if (collectionView.SelectedItem == null) return;
        await Shell.Current.GoToAsync("DoctorDetailsView");
        collectionView.SelectedItem = null;
    }

    private async void collectionOfSpecialists_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var collectionView = sender as CollectionView;
        if (collectionView.SelectedItem == null) return;
        await Shell.Current.GoToAsync("DoctorsView");
        collectionView.SelectedItem = null;
    }

}