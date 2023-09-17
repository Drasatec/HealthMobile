using DrasatHealthMobile.Models;
using DrasatHealthMobile.ViewModels;
using System.Windows.Input;

namespace DrasatHealthMobile.Views.Templates;

public partial class DropdownMenuTemplate : ContentView
{
    public ICommand ExpanderCommand => new Command(ddd);

    public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(
            nameof(Command),
            typeof(ICommand),
            typeof(EntryFrameTemplate));

    public static readonly BindableProperty MenuItemsSourceProperty =
        BindableProperty.Create(
            nameof(MenuItemsSource),
            typeof(List<DropdownMenuModel>),
            typeof(EntryFrameTemplate));

    public static readonly BindableProperty TextPlaceholderProperty =
        BindableProperty.Create(
            nameof(TextPlaceholder),
            typeof(string),
            typeof(EntryFrameTemplate),
            "insert text");

    public DropdownMenuTemplate()
    {
        InitializeComponent();
    }
    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }
    public List<DropdownMenuModel> MenuItemsSource
    {
        get => (List<DropdownMenuModel>)GetValue(MenuItemsSourceProperty);
        set => SetValue(MenuItemsSourceProperty, value);
    }

    public string TextPlaceholder
    {
        get => (string)GetValue(TextPlaceholderProperty);
        set => SetValue(TextPlaceholderProperty, value);
    }
    private async void CollectionOfItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        try
        {
            if (CollectionOfItems.SelectedItem == null)
                return;
            entry.Text = (CollectionOfItems.SelectedItem as DropdownMenuModel).Name;
            Command.Execute(CollectionOfItems.SelectedItem);
            CloseAnimation(dropdownContent, chevronIcon, separatorLine);
            CollectionOfItems.SelectedItem = null;
        }
        catch (Exception ex)
        {
            await Helpers.Helper.DisplayAlert(nameof(DropdownMenuTemplate), nameof(CollectionOfItems), ex.Message);
        }
    }

    #region Animation
    private void ddd()
    {
        if (!dropdownContent.IsVisible)
            OpenAnimation(dropdownContent, chevronIcon, separatorLine);
        else
            CloseAnimation(dropdownContent, chevronIcon, separatorLine);

    }

    void OpenAnimation(View container, View icon, View line)
    {
        container.HeightRequest = 0;
        container.IsVisible = true;
        line.IsVisible = true;
        line.Opacity = 0;

        new Animation
        {
            { 0  , 1, new Animation (v => container.HeightRequest = v, 0, CollectionOfItems.HeightRequest) },
            { 0  , 0.5, new Animation (v => container.Opacity = v, 0, 1) },
            { 0  , 1  , new Animation (v => icon.Rotation           = v, 0, 180) },
            { 0.5, 1  , new Animation (v => line.WidthRequest       = v, 0, this.Width) },
            { 0  , 1  , new Animation (v => line.Opacity            = v, 0, 1) }

        }.Commit(this, "OpenAnimations", 16, 250, easing: Easing.SinIn, (v, c) =>
        {
            //dropdown.Stroke = Color.FromArgb("#0070CD");
        });
    }

    void CloseAnimation(View container, View icon, View line)
    {
        new Animation
        {
            { 0  ,1, new Animation (v => container.HeightRequest = v, CollectionOfItems.HeightRequest,0) },
            { 0.6,1, new Animation (v => container.Opacity       = v, 1 , 0 ) },
            { 0  ,1, new Animation (v => icon.Rotation           = v, 180, 0) },
            { 0  ,1, new Animation (v => line.WidthRequest       = v, this.Width,0) }

        }.Commit(this, "CloseAnimations", 16, 250, easing: Easing.SinOut, (v, c) =>
        {
            container.IsVisible = false; line.IsVisible = false;
            //dropdown.Stroke = Color.FromArgb("#C8C8C8");
        });
    }
    #endregion


}