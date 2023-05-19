//using DrasatHealthMobile.Controls;

using DrasatHealthMobile.Views;

namespace DrasatHealthMobile;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new AppShell();//  NavigationPage(new HomeView());

        MainPage.FlowDirection = FlowDirection.RightToLeft;

        //ModifyEntry();
    }

    private void ModifyEntry()
    {
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("MyEntry", (handler, view) =>
        {

#if ANDROID
            handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#elif IOS || MACCATALYST
            handler.PlatformView.EditingDidBegin += (s, e) =>
            {
                handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
            };
#elif WINDOWS
            handler.PlatformView.GotFocus += (s, e) =>
            {
                handler.PlatformView.BorderThickness = new Microsoft.UI.Xaml.Thickness(0);
            };
#endif
        });
    }
}
