namespace DrasatHealthMobile.Views;

public partial class SearchView : ContentPage
{
    public SearchView()
    {
        InitializeComponent();
    }
    //protected async override void OnAppearing()
    //{
    //    base.OnAppearing();
    //    //await Task.Delay(500);
    //    //collectionOfSpecialists.IsVisible = true;
    //}
    private void ButtonSpecialist_Clicked(object sender, EventArgs e)
    {
        buttonSpecialist.Style = (Style)App.Current.Resources["Checked"];
        buttonDoctor.Style = (Style)App.Current.Resources["Unchecked"];
        stackOfDoctors.IsVisible = false;
        //StackResultFromSearch.Add(new Templates.BackButtonTemplate());
    }
    private void ButtonDoctor_Clicked(object sender, EventArgs e)
    {

        buttonDoctor.Style = (Style)App.Current.Resources["Checked"];


        buttonSpecialist.Style = (Style)App.Current.Resources["Unchecked"];
        stackOfDoctors.IsVisible = true;
        //StackResultFromSearch.Add(new Templates.BackButtonTemplate());
    }
}