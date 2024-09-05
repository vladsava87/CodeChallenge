namespace Api;

public static class ApiConstants
{
    public const string Host = "https://66d8c0d037b1cadd80559e13.mockapi.io/coffeeapi/v1/";
    
    public static class CoffeeEndpoints
    {
        public const string GetAllCoffeeTypes = "coffee";
        public const string GetCoffeeById = "coffee/{id}";
    }
}