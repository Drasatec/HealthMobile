﻿using Android.App;
using Android.Content.PM;
using Android.OS;

namespace DrasatHealthMobile;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    
    public MainActivity()
    {
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("MyEntry", (handler, view) =>
        {
            handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
            handler.PlatformView.HorizontalScrollBarEnabled = true;
        });

        //Microsoft.Maui.Handlers.ImageHandler.Mapper.AppendToMapping("MyImageButton", (handler, view) =>
        //{
        //    handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Red);
        //});

    }
}
