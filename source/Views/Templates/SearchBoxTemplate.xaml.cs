using System.Windows.Input;

namespace DrasatHealthMobile.Views.Templates;

public partial class SearchBoxTemplate : ContentView
{

    public static readonly BindableProperty CommandProperty =
                BindableProperty.Create(
                    nameof(Command),
                    typeof(ICommand), 
                    typeof(SearchBoxTemplate));

    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(
            nameof(Text),
            typeof(string),
            typeof(EntryFrameTemplate),
            string.Empty, BindingMode.TwoWay);

    public SearchBoxTemplate()
    {
        InitializeComponent();

    }

    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
}