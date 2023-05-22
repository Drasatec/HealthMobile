namespace DrasatHealthMobile.Views;

public partial class SpecialtiesView : ContentPage
{
    public SpecialtiesView()
    {
        InitializeComponent();
    }

    private async void collectionOfSpecialists_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var collectionView = sender as CollectionView;
        if (collectionView.SelectedItem == null) return;
        await Shell.Current.GoToAsync("DoctorsView");
        collectionView.SelectedItem = null;
    }
}