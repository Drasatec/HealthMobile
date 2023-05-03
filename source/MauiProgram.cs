using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Markup;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.LifecycleEvents;

namespace DrasatHealthMobile;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {

        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseMauiCommunityToolkitMarkup()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

                fonts.AddFont("materialdesignicons.ttf", "IconFontMaterial");
                fonts.AddFont("fa-regular-400.ttf", "IconFontFA");

                fonts.AddFont("Cairo-Regular.ttf", "CairoRegular");
                fonts.AddFont("Cairo-Bold.ttf", "CairoBold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.ConfigureLifecycleEvents(lifecycle =>
        {
#if WINDOWS

            lifecycle.AddWindows(windows => windows.OnWindowCreated((del) =>
            {
                del.ExtendsContentIntoTitleBar = true;
            }));
#endif
        });

        return builder.Build();
    }
}
