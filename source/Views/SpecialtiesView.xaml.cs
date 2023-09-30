using DrasatHealthMobile.Helpers;
using DrasatHealthMobile.Models.MedicalSpecialty;
using DrasatHealthMobile.ViewModels;
namespace DrasatHealthMobile.Views;

public partial class SpecialtiesView : ContentPage
{
    public SpecialtiesView(SpecialtiesViewModel specialtiesViewModel)
    {
        BindingContext = specialtiesViewModel;
        InitializeComponent();
    }
    protected override bool OnBackButtonPressed()
    {
        Helper.NavigationTo("///main");
        return true;
    }
    private void collectionOfSpecialists_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var collectionView = sender as CollectionView;
        if (collectionView.SelectedItem == null)
            return;
        var navigationParameter = new Dictionary<string, object>
        {
            { "Id", (collectionView.SelectedItem as SpecialtyModel).Id.ToString() }
        };

        Shell.Current.GoToAsync(nameof(DoctorsView), navigationParameter);
        collectionView.SelectedItem = null;
    }
}
