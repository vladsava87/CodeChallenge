using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Interfaces.Navigation;
using Interfaces.ViewModels;

namespace Business.ViewModels;

public class BaseViewModel : ObservableObject, IBasePageViewModel
{
    protected readonly INavigationService NavigationService;
    
    private ICommand _navigateBackCommand;

    public ICommand NavigateBackCommand
    {
        get => _navigateBackCommand;
        set => SetProperty(ref _navigateBackCommand, value);
    }

    public BaseViewModel(INavigationService navigationService)
    {
        NavigationService = navigationService;
        _navigateBackCommand = new AsyncRelayCommand(OnBackPressedAsync);
    }

    public async Task OnBackPressedAsync()
    {
        await NavigationService.PopAsync();
    }
    
    public async Task<bool> OnViewModelCreatedAsync(INavigationParameters parameters = null)
    {
        return true;
    }

    public async Task OnAppearAsync()
    {
    }

    public async Task OnDisappearAsync()
    {
    }
}