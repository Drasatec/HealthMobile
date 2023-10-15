using System.Linq.Expressions;
using System.Windows.Input;

namespace DrasatHealthMobile.Views.Templates;

public partial class ServiceCardTemplate : Border
{
    public ServiceCardTemplate() => InitializeComponent();


    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(
        nameof(Text),
        typeof(string),
        typeof(ServiceCardTemplate));
    
    public static readonly BindableProperty ImageSourceProperty =
        BindableProperty.Create(
        nameof(ImageSource),
        typeof(string),
        typeof(ServiceCardTemplate));

    public static readonly BindableProperty CommandParameterProperty =
       BindableProperty.Create(
       nameof(CommandParameter),
       typeof(string),
       typeof(ServiceCardTemplate));

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public string ImageSource
    {
        get => (string)GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }

    public string CommandParameter
    {
        get => (string)GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }

    public ICommand TapGestureRecognizerCommand => new Command<string>(TapGestureRecognizerExcute);
    async void  TapGestureRecognizerExcute(string parm)
    {
        switch (parm)
        {
            case "1":
                await Shell.Current.GoToAsync("///specialties");
                break;
            case "2":
                await Shell.Current.GoToAsync("MedicalServicesView");
                break;
            case "3":
                await Shell.Current.GoToAsync("DoctorsView");
                break;
        }
    }
}