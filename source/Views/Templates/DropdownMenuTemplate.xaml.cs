using DrasatHealthMobile.Models;
using DrasatHealthMobile.ViewModels;
using System.Windows.Input;

namespace DrasatHealthMobile.Views.Templates;

public partial class DropdownMenuTemplate : ContentView
{
    int maximumHeightToCollectionView = 300;
    int maximumHeightToRow = 36;
    //public ICommand ExpanderCommand => new Command(ddd);
    public event EventHandler Clicked;

    public static readonly BindableProperty SelectionChangedCommandProperty =
        BindableProperty.Create(
            nameof(SelectionChangedCommand),
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
    public static readonly BindableProperty ErrorStyleProperty =
        BindableProperty.Create(
            nameof(ErrorStyle),
            typeof(bool),
            typeof(EntryFrameTemplate),
            false, BindingMode.TwoWay);

    public DropdownMenuTemplate()
    {
        InitializeComponent();
    }

    public ICommand SelectionChangedCommand
    {
        get => (ICommand)GetValue(SelectionChangedCommandProperty);
        set => SetValue(SelectionChangedCommandProperty, value);
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

    private async void CollectionOfItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        try
        {
            if (CollectionOfItems.SelectedItem == null)
                return;
            entry.Text = (CollectionOfItems.SelectedItem as DropdownMenuModel).Name;
            SelectionChangedCommand.Execute(CollectionOfItems.SelectedItem);
            ssss();
            CollectionOfItems.SelectedItem = null;
            ErrorStyle = false;
        }
        catch (Exception ex)
        {
            await Helpers.Helper.DisplayAlert(nameof(DropdownMenuTemplate), nameof(CollectionOfItems), ex.Message);
        }
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        ssss();
    }

    void ssss()
    {
        EventHandler handler = Clicked;
        handler?.Invoke(this, new EventArgs());
        OpenCloseAnimation();
    }
    public async void Close()
    {
        await CloseAnimation(dropdownContent, chevronIcon, separatorLine);
    }

    private async void OpenCloseAnimation()
    {
        if (!dropdownContent.IsVisible)
            await OpenAnimation(dropdownContent, chevronIcon, separatorLine);
        else
            await CloseAnimation(dropdownContent, chevronIcon, separatorLine);
    }

    #region Animation
    async Task OpenAnimation(View container, View icon, View line)
    {
        if (dropdownContent.IsVisible) return;

        var height = MenuItemsSource.Count * maximumHeightToRow;
        if (height > maximumHeightToCollectionView)
        {
            height = maximumHeightToCollectionView;
        }
        container.HeightRequest = 0;
        container.IsVisible = true;
        line.IsVisible = true;
        line.Opacity = 0;

        await Task.Run(() =>
        {
            new Animation
            {
                { 0  , 1, new Animation (v => container.HeightRequest = v, 0, height) },
                { 0  , 0.5, new Animation (v => container.Opacity = v, 0, 1) },
                { 0  , 1  , new Animation (v => icon.Rotation           = v, 0, 180) },
                { 0.5, 1  , new Animation (v => line.WidthRequest       = v, 0, this.Width) },
                { 0  , 1  , new Animation (v => line.Opacity            = v, 0, 1) }

            }.Commit(this, "OpenAnimations", 16, 300, easing: Easing.SinIn, null);//  (v, c) =>{}
        });
        //maneBorder.Stroke = Color.FromArgb("#0070CD");
    }

    async Task CloseAnimation(View container, View icon, View line)
    {
        if (!dropdownContent.IsVisible) return;
        await Task.Run(() =>
        {
            new Animation
            {
                { 0  ,1, new Animation ( v => container.HeightRequest = v, container.HeightRequest,0) },
                { 0.6,1, new Animation (v => container.Opacity       = v, 1 , 0 ) },
                { 0  ,1, new Animation (v => icon.Rotation           = v, 180, 0) },
                { 0  ,1, new Animation (v => line.WidthRequest       = v, this.Width,0) }

            }.Commit(this, "CloseAnimations", 16, 300, easing: Easing.SinOut, (v, c) => 
                { 
                    container.IsVisible = false; line.IsVisible = false;
                    //maneBorder.Stroke = Color.FromArgb("#C8C8C8");
                });
        });
    }
    #endregion
}