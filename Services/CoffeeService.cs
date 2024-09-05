using Api.Interfaces;
using Models.Coffee;
using Services.Interfaces;

namespace Services;

public class CoffeeService : ICoffeeService
{
    private ICoffeeApiClient _coffeeApiClient;
    
    public CoffeeService(ICoffeeApiClient coffeeApiClient)
    {
        _coffeeApiClient = coffeeApiClient;
    }
    
    public Task<IList<CoffeeModel>> GetAllCoffeeTypesAsync()
    {
        return _coffeeApiClient.GetAllCoffeeTypesAsync();
    }
    
    public Task<CoffeeModel> GetCoffeeByIdAsync(int id)
    {
        return _coffeeApiClient.GetCoffeeByIdAsync(id);
    }
}