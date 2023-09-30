using The49.Maui.BottomSheet;
using DrasatHealthMobile.Models;
namespace DrasatHealthMobile.Views.Templates;

public partial class SelectHospitalBottomSheet : BottomSheet
{
    public event EventHandler Clicked;

    public SelectHospitalBottomSheet(List<HospitalTranslation> hospitalTranslations)
	{
		InitializeComponent();
        hossCollections.ItemsSource = hospitalTranslations;
    }
    private HospitalTranslation _hospital;
    private HospitalTranslation Hospital;

    public HospitalTranslation GetValueMy()
	{
		return Hospital;
	}

    private void hossCollections_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        _hospital = hossCollections.SelectedItem as HospitalTranslation;
    }

    private void BtnSubmit_Clicked(object sender, EventArgs e)
    {
        Hospital = _hospital;
        this.DismissAsync();
    }
}