namespace DrasatHealthMobile.Views;

public partial class DoctorDetailsView : ContentPage
{
    public DoctorDetailsView()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }
    int flag = 0;
    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        var uuu= (sender) as Label;
        if (flag == 0)
        {
            uuu.Text = "أقل";
            label.MaxLines = default;
            label.LineBreakMode = LineBreakMode.WordWrap;
            flag = 1;
        }
        else
        {
            uuu.Text = "قراءة المزيد";
            label.MaxLines = 3;
            label.LineBreakMode = LineBreakMode.TailTruncation;
            flag = 0;
        }
    }
}