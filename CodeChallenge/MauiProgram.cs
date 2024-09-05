using Api;
using Api.Interfaces;
using Business.ViewModels;
using CodeChallenge.Navigation;
using CodeChallenge.Views;
using CommunityToolkit.Maui;
using FFImageLoading.Maui;
using Interfaces.ViewModels;
using Interfaces.Views;
using Microsoft.Extensions.Logging;
using Services;
using Services.Interfaces;

namespace CodeChallenge;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseFFImageLoading()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.SetupServices();
        builder.SetupViewModels();
        builder.SetupViews();
        
#if DEBUG
        builder.Logging.AddDebug();
#endif
        
        return builder.Build();
    }

    private static void SetupServices(this MauiAppBuilder mauiApp)
    {
        mauiApp.Services.AddSingleton<IViewService, ViewService>();
        mauiApp.Services.AddSingleton<INavigationService, NavigationService>();
        mauiApp.Services.AddSingleton<ICoffeeApiClient, CoffeeApiClient>();
        mauiApp.Services.AddSingleton<ICoffeeService, CoffeeService>();
    }
    
    private static void SetupViews(this MauiAppBuilder mauiApp)
    {
        mauiApp.Services.AddSingleton<ICoffeePage, CoffeePage>();
        mauiApp.Services.AddSingleton<ICoffeeDetailPage, CoffeeDetailPage>();
    }
    
    private static void SetupViewModels(this MauiAppBuilder mauiApp)
    {
        mauiApp.Services.AddSingleton<ICoffeeViewModel, CoffeeViewModel>();
        mauiApp.Services.AddSingleton<ICoffeeDetailViewModel, CoffeeDetailViewModel>();
    }
}