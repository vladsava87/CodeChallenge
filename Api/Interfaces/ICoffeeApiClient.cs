using Models.Coffee;

namespace Api.Interfaces;

public interface ICoffeeApiClient
{
    Task<IList<CoffeeModel>> GetAllCoffeeTypesAsync();
    Task<CoffeeModel> GetCoffeeByIdAsync(int id);
}