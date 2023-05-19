namespace DrasatHealthMobile.Views.Templates;

public partial class DoctorCardTemplate : ContentView
{
    public DoctorCardTemplate()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty CommandParameterProperty =
      BindableProperty.Create(
      nameof(CommandParameter),
      typeof(string),
      typeof(ServiceCardTemplate));

    public string CommandParameter
    {
        get => (string)GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var param = button.CommandParameter;
        await Shell.Current.GoToAsync("BookingByPatient");
    }
}