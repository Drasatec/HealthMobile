using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using System.Windows.Input;

namespace DrasatHealthMobile.Views.Templates;

public partial class DropdownListEntryTemplate : Grid
{
    public DropdownListEntryTemplate()
    {
        InitializeComponent();
    }

    public ICommand ExpanderCommand => new Command(ddd);

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
            { 0  , 1, new Animation (v => container.HeightRequest = v, 0, 200) },
            { 0  , 0.5, new Animation (v => container.Opacity = v, 0, 1) },
            { 0  , 1  , new Animation (v => icon.Rotation           = v, 0, 180) },
            { 0.5, 1  , new Animation (v => line.WidthRequest       = v, 0, this.Width) },
            { 0  , 1  , new Animation (v => line.Opacity            = v, 0, 1) }

        }.Commit(this, "OpenAnimations", 16, 500, easing: Easing.Linear, (v, c) =>
        {
            dropdown.Stroke = Color.FromArgb("#0070CD");
        });
    }

    void CloseAnimation(View container, View icon, View line)
    {
        new Animation
        {
            { 0  ,1, new Animation (v => container.HeightRequest = v, 200,0) },
            { 0.6,1, new Animation (v => container.Opacity       = v, 1 , 0 ) },
            { 0  ,1, new Animation (v => icon.Rotation           = v, 180, 0) },
            { 0  ,1, new Animation (v => line.WidthRequest       = v, this.Width,0) }

        }.Commit(this, "CloseAnimations", 16, 500, easing:Easing.Linear, (v, c) =>
        {
            container.IsVisible = false; line.IsVisible = false;
            dropdown.Stroke = Color.FromArgb("#C8C8C8");
        });
    }
}