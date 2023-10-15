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
using The49.Maui.BottomSheet;

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
            .UseBottomSheet()
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

        builder.Services.AddTransient<HomeViewModel>();
        builder.Services.AddTransient<HomeView>();

        builder.Services.AddSingleton<SpecialtiesViewModel>();
        builder.Services.AddSingleton<SpecialtiesView>();

        builder.Services.AddSingleton<DoctorsViewModel>();
        builder.Services.AddSingleton<DoctorsView>();
        
        builder.Services.AddTransient<RegisterViewModel>();
        builder.Services.AddTransient<RegisterView>();
        
        
        builder.Services.AddTransient<DoctorDetailsViewModel>();
        builder.Services.AddTransient<DoctorDetailsView>();

        builder.Services.AddTransient<AddBookingViewModel>();
        builder.Services.AddTransient<AddBookingView>();
        
        builder.Services.AddTransient<BookingDetailsViewModel>();
        builder.Services.AddTransient<BookingDetailsView>();


        builder.Services.AddTransient<LoginView>();
        builder.Services.AddSingleton<BookingsView>();
        builder.Services.AddSingleton<ProfileView>();


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
