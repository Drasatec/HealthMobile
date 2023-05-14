using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Views.InputMethods;

namespace DrasatHealthMobile;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    
    public MainActivity()
    {
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("MyEntry", (handler, view) =>
        {
           handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
           // handler.PlatformView.HorizontalScrollBarEnabled = true;
        });

        //var context = Android.App.Application.Context;
        //var inputMethodManager = context.GetSystemService(Context.InputMethodService) as InputMethodManager;
        //if (inputMethodManager != null && context is Activity)
        //{
        //    var activity = context as Activity;
        //    var token = activity.CurrentFocus?.WindowToken;
        //    inputMethodManager.HideSoftInputFromWindow(token, HideSoftInputFlags.None);
        //    activity.Window.DecorView.ClearFocus();
        //}

    }
}
