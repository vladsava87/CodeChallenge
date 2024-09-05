using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Interfaces.Navigation;
using Interfaces.ViewModels;
using Interfaces.Views;
using Models.Coffee;
using Models.Navigation;
using Services.Interfaces;
using Services.Navigation;

namespace Business.ViewModels;

public class CoffeeViewModel : BaseViewModel, ICoffeeViewModel
{
    private readonly ICoffeeService _coffeeService;

    private ObservableCollection<CoffeeModel> _coffeeProducts;
    public ObservableCollection<CoffeeModel> CoffeeProducts
    {
        get => _coffeeProducts;
        set => SetProperty(ref _coffeeProducts, value);
    }
    
    private ICommand _selectedCoffeeProductCommand;
    public ICommand SelectedCoffeeProductCommand
    {
        get
        {
            return _selectedCoffeeProductCommand = new AsyncRelayCommand<int>(OnSelectedCoffeeProductCommand); 
        }
    }
    
    public CoffeeViewModel(ICoffeeService coffeeService, 
        INavigationService navigationService) 
        : base(navigationService)
    {
        _coffeeService = coffeeService;
    }

    public async Task<bool> OnViewModelCreatedAsync(INavigationParameters parameters = null)
    {
        var coffeeProducts = await _coffeeService.GetAllCoffeeTypesAsync();
        CoffeeProducts = new ObservableCollection<CoffeeModel>(coffeeProducts);

        return true;//await base.OnViewModelCreatedAsync(parameters);
    }
    
    private async Task OnSelectedCoffeeProductCommand(int arg)
    {
        await NavigationService.PushAsync(typeof(ICoffeeDetailPage), new NavigationParameters(NavigationParameterField.CoffeeId, arg));
    }
}