using Interfaces.Views;
using Services.Interfaces;

namespace CodeChallenge;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        
        var navigationService = ServiceLocator.GetService<INavigationService>();
        MainPage = new AppShell();
        navigationService.InitializeAsync(typeof(ICoffeePage));
    }
}