using Api.Interfaces;
using Models.Coffee;
using Moq;
using Services;
using UnitTests.Helper;

namespace UnitTests.ServiceTests;

[TestFixture]
public class CoffeeServiceTests
{
    private Mock<ICoffeeApiClient> _mockCoffeeApiClient;
    private CoffeeService _coffeeService;
    private List<CoffeeModel> _coffeeModels;
    
    [SetUp]
    public void Setup()
    {
        _mockCoffeeApiClient = new Mock<ICoffeeApiClient>();
        _coffeeService = new CoffeeService(_mockCoffeeApiClient.Object);
        _coffeeModels = CoffeeHelper.GetCoffees();
    }
    
#pragma warning disable NUnit1007
    [Test]
#pragma warning restore NUnit1007
    public async Task GetCoffeeProducts_ReturnsCorrectProducts()
    {
        _mockCoffeeApiClient
            .Setup(client => client.GetAllCoffeeTypesAsync())
            .ReturnsAsync(_coffeeModels);

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
        _mockCoffeeApiClient
            .Setup(client => client.GetCoffeeByIdAsync(2))
            .ReturnsAsync(_coffeeModels.FirstOrDefault(coffee => coffee.Id == 2));

        var result = await _coffeeService.GetCoffeeByIdAsync(2);
        
        Assert.That("Cappuccino", Is.EqualTo(result.Name));
    }
}