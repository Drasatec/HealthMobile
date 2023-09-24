using DrasatHealthMobile.Helpers;
using Microsoft.Maui;
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

    public static readonly BindableProperty TextProperty =
            BindableProperty.Create(
                nameof(Text),
                typeof(string),
                typeof(EntryFrameTemplate),
                string.Empty, BindingMode.TwoWay);

    public static readonly BindableProperty EntryKeyboardProperty =
            BindableProperty.Create(
                nameof(EntryKeyboard),
                typeof(string),
                typeof(EntryFrameTemplate),
                "Text", BindingMode.TwoWay);

    public static readonly BindableProperty IsPasswordProperty =
            BindableProperty.Create(
                nameof(IsPassword),
                typeof(bool),
                typeof(EntryFrameTemplate),
                false, BindingMode.TwoWay);

    public static readonly BindableProperty ErrorStyleProperty =
            BindableProperty.Create(
                nameof(ErrorStyle),
                typeof(bool),
                typeof(EntryFrameTemplate),
                false, BindingMode.TwoWay);

    public static readonly BindableProperty HasEyeIconProperty =
            BindableProperty.Create(
                nameof(HasEyeIcon),
                typeof(bool),
                typeof(EntryFrameTemplate),
                false, BindingMode.TwoWay);

    public EntryFrameTemplate()
    {
        InitializeComponent();
        //entry.IsPassword = IsPassword;
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

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public string EntryKeyboard
    {
        get => (string)GetValue(EntryKeyboardProperty);
        set => SetValue(EntryKeyboardProperty, value);
    }

    public bool IsPassword
    {
        get => (bool)GetValue(IsPasswordProperty);
        set { SetValue(IsPasswordProperty, value); }
    }

    public bool ErrorStyle
    {
        get => (bool)GetValue(ErrorStyleProperty);
        set
        {
            SetValue(ErrorStyleProperty, value);
            if (value)
            {
                maneBorder.Stroke = Color.FromArgb("#df4759");
            }
            else
            {
                maneBorder.Stroke = default;
            }
            OnPropertyChanged(nameof(ErrorStyle));
        }
    }
    public void InValidStyle()
    {
        ErrorStyle = true;
    }

    public void ValidStyle()
    {
        ErrorStyle = false;
    }
    public bool HasEyeIcon
    {
        get => (bool)GetValue(HasEyeIconProperty);
        set { SetValue(HasEyeIconProperty, value); }
    }

    int t = 1;
    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        if (t == 1)
        {
            IsPassword = false;
            eyeIcon.Text = IconFontMaterial.Eye;
            t = 2;
        }
        else
        {
            IsPassword = true;
            eyeIcon.Text = IconFontMaterial.EyeOff;
            t = 1;
        }
    }
}