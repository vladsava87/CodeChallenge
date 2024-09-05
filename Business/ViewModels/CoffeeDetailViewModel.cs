using Interfaces.Navigation;
using Interfaces.ViewModels;
using Models.Coffee;
using Models.Navigation;
using Services.Interfaces;

namespace Business.ViewModels;

public class CoffeeDetailViewModel : BaseViewModel, ICoffeeDetailViewModel
{
    private readonly ICoffeeService _coffeeService;
    
    private CoffeeModel _coffee;
    public CoffeeModel Coffee
    {
        get => _coffee;
        set => SetProperty(ref _coffee, value);
    }
    
    public CoffeeDetailViewModel(INavigationService navigationService,
        ICoffeeService coffeeService) 
        : base(navigationService)
    {
        _coffeeService = coffeeService;
    }

    public async Task<bool> OnViewModelCreatedAsync(INavigationParameters parameters = null)
    {
        if (parameters.GetParameter<int>(NavigationParameterField.CoffeeId) is var id)
        {
            Coffee = await _coffeeService.GetCoffeeByIdAsync(id);
        }
        
        return await base.OnViewModelCreatedAsync(parameters);
    }
}