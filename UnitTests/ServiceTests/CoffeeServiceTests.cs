using Services;
using Services.Interfaces;

namespace UnitTests.ServiceTests;

[TestFixture]
public class CoffeeServiceTests
{
    private ICoffeeService _coffeeService;
    
    [SetUp]
    public void Setup()
    {
        _coffeeService = new CoffeeService();
    }
    
#pragma warning disable NUnit1007
    [Test]
#pragma warning restore NUnit1007
    public async Task GetCoffeeProducts_ReturnsCorrectProducts()
    {
        var result = await _coffeeService.GetAllCoffeeTypesAsync();

        Assert.That(3, Is.EqualTo(result.Count));
        Assert.That("Espresso", Is.EqualTo(result[0].Name));
        Assert.That("Latte", Is.EqualTo(result[2].Name));
    }
    
#pragma warning disable NUnit1007
    [Test]
#pragma warning restore NUnit1007
    public async Task GetCoffeeProducts_ReturnSingleProduct()
    {
        var result = await _coffeeService.GetCoffeeByIdAsync(2);
        
        Assert.That("Cappuccino", Is.EqualTo(result.Name));
    }
}