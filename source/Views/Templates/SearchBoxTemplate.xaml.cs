using System.Windows.Input;

namespace DrasatHealthMobile.Views.Templates;

public partial class SearchBoxTemplate : ContentView
{

    public static readonly BindableProperty CommandProperty =
                BindableProperty.Create(
                    nameof(Command),
                    typeof(ICommand), 
                    typeof(SearchBoxTemplate));

    public SearchBoxTemplate()
    {
        InitializeComponent();

    }

    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

}