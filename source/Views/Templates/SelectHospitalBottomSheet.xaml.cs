using The49.Maui.BottomSheet;
using DrasatHealthMobile.Models;
namespace DrasatHealthMobile.Views.Templates;

public partial class SelectHospitalBottomSheet : BottomSheet
{
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

    private void HossCollections_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        _hospital = hossCollections.SelectedItem as HospitalTranslation;
    }

    private void BtnSubmit_Clicked(object sender, EventArgs e)
    {
        try
        {
            Hospital = _hospital;
            this.DismissAsync();
        }
        catch (Exception)
        {
        }
       
    }
}