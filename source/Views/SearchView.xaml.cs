namespace DrasatHealthMobile.Views;

public partial class SearchView : ContentPage
{
    public SearchView()
    {
        InitializeComponent();
    }
    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var collection = (CollectionView)sender;
        if (collection != null) return;


        collection.SelectedItem = null;
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
}