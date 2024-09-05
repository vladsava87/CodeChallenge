using Interfaces.Navigation;
using Interfaces.Views;

namespace Services.Interfaces;

public interface INavigationService
{
    INavigationPage MainNavigationPage { get; set; }
    Task InitializeAsync(Type page);
    Task PushAsync(Type pageKey, INavigationParameters parameter = null, bool animated = true);
    Task PopAsync(INavigationParameters parameter = null, bool animated = true);
    Task PopToRootAsync();
}