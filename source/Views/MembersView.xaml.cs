namespace DrasatHealthMobile.Views;

public partial class MembersView : ContentPage
{
	public MembersView()
	{
		InitializeComponent();

    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        collectionGroup.SelectedItem = ((string[])collectionGroup.ItemsSource)[1];

    }
}