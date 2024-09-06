using Business.ViewModels;
using Interfaces.Navigation;
using Interfaces.Views;
using Models.Coffee;
using Models.Navigation;
using Moq;
using Services.Interfaces;
using UnitTests.Helper;

namespace UnitTests.ViewModelTests;

[TestFixture]
public class CoffeeViewModelTests
{
    private Mock<ICoffeeService> _mockCoffeeService;
    private Mock<INavigationService> _mockNavigationService;
    private CoffeeViewModel _coffeeViewModel;
    private List<CoffeeModel> _coffeeModels;
    
    [SetUp]
    public void Setup()
    {
        _mockCoffeeService = new Mock<ICoffeeService>();
        _mockNavigationService = new Mock<INavigationService>();

        _coffeeViewModel = new CoffeeViewModel(_mockCoffeeService.Object, _mockNavigationService.Object);
        _coffeeModels = CoffeeHelper.GetCoffees();
    }
    
    [Test]
    public async Task OnViewModelCreatedAsync_ShouldPopulateCoffeeProducts()
    {
        _mockCoffeeService
            .Setup(service => service.GetAllCoffeeTypesAsync())
            .ReturnsAsync(_coffeeModels);

        await _coffeeViewModel.OnViewModelCreatedAsync();

        
        Assert.That(_coffeeViewModel.CoffeeProducts, !Is.EqualTo(null));
        Assert.That(3, Is.EqualTo(_coffeeViewModel.CoffeeProducts.Count));
        Assert.That("Espresso", Is.EqualTo(_coffeeViewModel.CoffeeProducts[0].Name));
        Assert.That("Cappuccino", Is.EqualTo(_coffeeViewModel.CoffeeProducts[1].Name));
    }
    
    [Test]
    public async Task SelectedCoffeeProductCommand_ShouldNavigateToCoffeeDetailPage()
    {
        const int coffeeId = 1;

        await _coffeeViewModel.SelectedCoffeeProductCommand.ExecuteAsync(coffeeId);
        
        // Mock the navigation parameters to ensure it's passing the correct CoffeeId
        var mockNavigationParameters = new Mock<INavigationParameters>();
        mockNavigationParameters.Setup(p => p.GetParameter<int>(NavigationParameterField.CoffeeId))
            .Returns(coffeeId);

        // Assert: Ensure the navigation service is called with the correct parameters
        _mockNavigationService.Verify(navService => 
                navService.PushAsync(
                    typeof(ICoffeeDetailPage), 
                    It.Is<INavigationParameters>(p => p.GetParameter<int>(NavigationParameterField.CoffeeId) == coffeeId),
                    true 
                ), 
            Times.Once);
    }
    
    [Test]
    public async Task OnViewModelCreatedAsync_WhenNoCoffeeProducts_ReturnsEmptyCollection()
    {
        _mockCoffeeService
            .Setup(service => service.GetAllCoffeeTypesAsync())
            .ReturnsAsync(new List<CoffeeModel>());

        await _coffeeViewModel.OnViewModelCreatedAsync();
        
        Assert.That(_coffeeViewModel.CoffeeProducts, !Is.EqualTo(null));
        Assert.That(0, Is.EqualTo(_coffeeViewModel.CoffeeProducts.Count));
    }
    
    [Test]
    public void CoffeeViewModel_ShouldInitializeWithEmptyCoffeeProducts()
    {
        Assert.That(_coffeeViewModel.CoffeeProducts, !Is.EqualTo(null));
        Assert.That(0, Is.EqualTo(_coffeeViewModel.CoffeeProducts.Count));
    }
}