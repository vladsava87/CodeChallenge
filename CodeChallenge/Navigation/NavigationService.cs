using System.Diagnostics;
using Interfaces.Navigation;
using Interfaces.ViewModels;
using Interfaces.Views;
using Services.Interfaces;

namespace CodeChallenge.Navigation;

public class NavigationService : INavigationService
{
    private static SemaphoreSlim _lock = new SemaphoreSlim(1, 1);
    private readonly IViewService _viewService;
    
    public bool CanGoBack => Shell.Current.Navigation.NavigationStack.Count > 1;
    
    public NavigationService(IViewService viewService)
    {
        _viewService = viewService;
    }
    
    public INavigationPage MainNavigationPage { get; set; }
    
    public async Task InitializeAsync(Type page)
    {
        try
        {
            MainNavigationPage = _viewService.CreatePage(page);
            
            if (!(MainNavigationPage.DataContext is IBasePageViewModel viewModel))
            {
                throw new NullReferenceException($"ViewModel not found on initialize navigation service");
            }
            
            var shellContent = new ShellContent
            {
                Content = MainNavigationPage,
                Route = page.Name
            };
            
            if (!Shell.Current.Items.Any())
            {
                Shell.Current.Items.Add(shellContent);
            }
            else
            {
                Shell.Current.Items[0] = shellContent;
            }
            Shell.Current.CurrentItem = shellContent;

            await viewModel.OnViewModelCreatedAsync().ConfigureAwait(false);
            await viewModel.OnAppearAsync().ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            Debugger.Break();
        }
    }
    
    public async Task PopAsync(INavigationParameters parameter = null, bool animated = true)
    {
        if (CanGoBack)
        {
            try
            {
                await MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    await Shell.Current.Navigation.PopAsync(animated);

                    if (Shell.Current.CurrentPage.BindingContext is IBasePageViewModel
                        viewModel)
                    {
                        if (parameter != null)
                        {
                            await viewModel.OnViewModelCreatedAsync(parameter).ConfigureAwait(false);
                        }
                        
                        await viewModel.OnAppearAsync().ConfigureAwait(false);
                    }
                });
            } 
            catch (Exception ex)
            {
                Debugger.Break();
            }
        }
    }
    
    public async Task PopToRootAsync()
    {
        await Shell.Current.GoToAsync("//", true);
    }
    
    public async Task PushAsync(Type pageKey,
        INavigationParameters parameter = null,
        bool animated = true)
    {
        await _lock.WaitAsync();

        try
        {
            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                var page = _viewService.CreatePage(pageKey);
                if (!(page.DataContext is IBasePageViewModel viewModel))
                {
                    throw new NullReferenceException($"ViewModel not found for {pageKey.Name}");
                }

                var viewModelCreated = await viewModel.OnViewModelCreatedAsync(parameter);
                if (!viewModelCreated)
                {
                    return;
                }

                await Shell.Current.Navigation.PushAsync(page as ContentPage, animated);

                await viewModel.OnAppearAsync().ConfigureAwait(false);
            });
        }
        catch (Exception ex)
        {
            Debugger.Break();
        }
        finally
        {
            _lock.Release();
        }
    }
}