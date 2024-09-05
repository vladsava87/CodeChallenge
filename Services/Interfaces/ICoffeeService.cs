using Models.Coffee;

namespace Services.Interfaces;

public interface ICoffeeService
{
    Task<IList<CoffeeModel>> GetAllCoffeeTypesAsync();
    Task<CoffeeModel> GetCoffeeByIdAsync(int id);
}