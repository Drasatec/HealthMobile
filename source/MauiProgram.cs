using DrasatHealthMobile.Services.Home;
using DrasatHealthMobile.Services.PublicServices;
using DrasatHealthMobile.Services.RequestProvider;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Markup;
using DrasatHealthMobile.ViewModels;
using DrasatHealthMobile.Views;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Hosting;
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
        builder.Services.AddSingleton<IRequestProvider, RequestProvider>();
        builder.Services.AddSingleton<IHomeServices, HomeServices>();
        builder.Services.AddSingleton<IPublicService, PublicService>();

        builder.Services.AddSingleton<HomeViewModel>();
        builder.Services.AddSingleton<HomeView>();

        builder.Services.AddSingleton<SpecialtiesViewModel>();
        builder.Services.AddSingleton<SpecialtiesView>();

        builder.Services.AddSingleton<DoctorsViewModel>();
        builder.Services.AddSingleton<DoctorsView>();
        
        builder.Services.AddSingleton<RegisterViewModel>();
        builder.Services.AddSingleton<RegisterView>();

        builder.Services.AddSingleton<LoginView>();

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
