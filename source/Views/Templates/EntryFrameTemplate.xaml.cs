using System.Windows.Input;

namespace DrasatHealthMobile.Views.Templates;

public partial class EntryFrameTemplate : ContentView
{
    public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(
                nameof(Command),
                typeof(ICommand),
                typeof(EntryFrameTemplate));
    
    public static readonly BindableProperty TextPlaceholderProperty =
            BindableProperty.Create(
                nameof(TextPlaceholder),
                typeof(string),
                typeof(EntryFrameTemplate),
                "insert text");

    public EntryFrameTemplate()
    {
        InitializeComponent();
    }

    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public string TextPlaceholder
    {
        get => (string)GetValue(TextPlaceholderProperty);
        set => SetValue(TextPlaceholderProperty, value);
    }
}