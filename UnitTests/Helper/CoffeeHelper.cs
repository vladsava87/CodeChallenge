using Models.Coffee;

namespace UnitTests.Helper;

public static class CoffeeHelper
{
    public static List<CoffeeModel> GetCoffees()
    {
        return
        [
            new CoffeeModel { Id = 1, Name = "Espresso", Description = "A strong and concentrated coffee made by forcing hot water through finely-ground coffee beans.", Image = "espresso"},
            new CoffeeModel { Id = 2, Name = "Cappuccino", Description = "Equal parts espresso, steamed milk, and milk foam, creating a creamy and frothy drink.", Image = "capuccino"},
            new CoffeeModel { Id = 3, Name = "Latte", Description = "Similar to a cappuccino but with more steamed milk and less foam, resulting in a milder flavor.", Image = "latte"}
        ];
    }
}