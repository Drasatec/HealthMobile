using Microsoft.Maui.Controls;

namespace DrasatHealthMobile.Views;

public partial class DoctorsView : ContentPage
{
	public DoctorsView()
	{
		InitializeComponent();
	}
    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var collection = (CollectionView)sender;
        if (collection != null) return;


        collection.SelectedItem = null;
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {

    }

    private void CollectionView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
    {
        //VisualStateManager.GoToState(visualStack, "Invalid");

    }
}