using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Views;
using Android.Views.InputMethods;
using System.Globalization;

namespace DrasatHealthMobile;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{

    public MainActivity()
    {
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("MyEntry", (handler, view) =>
        {
            handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
        });

        Microsoft.Maui.Handlers.DatePickerHandler.Mapper.AppendToMapping("MyDatePicker", (handler, view) =>
        {
            handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
        });

        Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping("MyPicker", (handler, view) =>
        {
            handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
        });
    }
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Set the LayoutDirection to RTL (right-to-left)
        //Window.DecorView.LayoutDirection = Android.Views.LayoutDirection.Rtl;
        var ss = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
        if (ss == "ar")
        {
            Window.DecorView.LayoutDirection = Android.Views.LayoutDirection.Rtl;
        }
        else
        {
            Window.DecorView.LayoutDirection = Android.Views.LayoutDirection.Ltr;

        }

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


    //#region this code implement => How to keep soft keyboard always open in Xamarin Forms
    //private bool _lieAboutCurrentFocus;

    //public override bool DispatchTouchEvent(MotionEvent ev)
    //{
    //    var focused = CurrentFocus;
    //    bool customEntryRendererFocused = focused != null && focused.Parent is Entry;

    //    _lieAboutCurrentFocus = customEntryRendererFocused;
    //    var result = base.DispatchTouchEvent(ev);
    //    _lieAboutCurrentFocus = false;
    //    return result;
    //}
    //public override Android.Views.View CurrentFocus
    //{
    //    get
    //    {
    //        if (_lieAboutCurrentFocus)
    //        {
    //            return null;
    //        }

    //        return base.CurrentFocus;
    //    }
    //}
    //#endregion
}
