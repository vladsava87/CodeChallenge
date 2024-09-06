using Api;
using Models.Coffee;
using Moq;
using Newtonsoft.Json;
using RestSharp;
using UnitTests.Helper;

namespace UnitTests.ServiceTests;

[TestFixture]
public class CoffeeApiClientTests
{
    private Mock<IRestClient> _mockRestClient;
    private CoffeeApiClient _coffeeApiClient;
    private List<CoffeeModel> _coffeeModels;

    [SetUp]
    public void Setup()
    {
        _mockRestClient = new Mock<IRestClient>();
        _coffeeApiClient = new CoffeeApiClient(_mockRestClient.Object);
        _coffeeModels = CoffeeHelper.GetCoffees();
    }
    
#pragma warning disable NUnit1007
    [Test]
#pragma warning restore NUnit1007
    public async Task GetAPICoffeeProducts_ReturnsAllProducts()
    {
        var jsonResponse = JsonConvert.SerializeObject(_coffeeModels);
        
        var mockResponse = new RestResponse
        {
            StatusCode = System.Net.HttpStatusCode.OK,
            Content = jsonResponse,
            ResponseStatus = ResponseStatus.Completed,
            IsSuccessStatusCode = true,
        };

        _mockRestClient
            .Setup(client => client.ExecuteAsync(It.IsAny<RestRequest>(), default))
            .ReturnsAsync(mockResponse);

        var result = await _coffeeApiClient.GetAllCoffeeTypesAsync();

        Assert.That(3, Is.EqualTo(result.Count));
        Assert.That("Espresso", Is.EqualTo(result[0].Name));
        Assert.That("Cappuccino", Is.EqualTo(result[1].Name));
    }
    
#pragma warning disable NUnit1007
    [Test]
#pragma warning restore NUnit1007
    public async Task GetAPICoffeeProducts_ReturnsOneProduct()
    {
        var jsonResponse = JsonConvert.SerializeObject(_coffeeModels[1]);
        
        var mockResponse = new RestResponse
        {
            StatusCode = System.Net.HttpStatusCode.OK,
            Content = jsonResponse,
            ResponseStatus = ResponseStatus.Completed,
            IsSuccessStatusCode = true,
        };

        _mockRestClient
            .Setup(client => client.ExecuteAsync(It.IsAny<RestRequest>(), default))
            .ReturnsAsync(mockResponse);

        var result = await _coffeeApiClient.GetCoffeeByIdAsync(2);
        
        Assert.That(result, !Is.EqualTo(null));
        Assert.That(result.GetType(), Is.EqualTo(typeof(CoffeeModel)));
        Assert.That("Cappuccino", Is.EqualTo(result.Name));
    }
}