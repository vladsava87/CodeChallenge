using Interfaces.Navigation;

namespace Interfaces.ViewModels;

public interface IBasePageViewModel
{
    Task<bool> OnViewModelCreatedAsync(INavigationParameters parameters = null);
    Task OnAppearAsync();
    Task OnDisappearAsync();
    Task OnBackPressedAsync();
}