using Api.Interfaces;
using Interfaces.Data;
using Models.Coffee;
using Newtonsoft.Json;
using RestSharp;

// API Mock implementation 
// =======================
// https://mockapi.io/clone/66d8c0d037b1cadd80559e14
// =======================

namespace Api;

public class CoffeeApiClient : ApiClient, ICoffeeApiClient
{
    public CoffeeApiClient() : base()
    {
    }
    
    public CoffeeApiClient(IRestClient restClient) : base(restClient)
    {
    }

    public async Task<IList<CoffeeModel>> GetAllCoffeeTypesAsync()
    {
        List<CoffeeModel> coffeeModels = null;

        try
        {
            var request = new RestRequest(ApiConstants.CoffeeEndpoints.GetAllCoffeeTypes)
                .AddHeader("Accept", "application/vnd.api+json");

            var jsonResponse = await RestClient.ExecuteAsync(request).ConfigureAwait(false);

            if (jsonResponse is { IsSuccessful: true, Content: not null })
            {
                coffeeModels = JsonConvert.DeserializeObject<List<CoffeeModel>>(jsonResponse.Content);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"APILOG: {ex.StackTrace}");
        }

        return coffeeModels;
    }
    
    public async Task<CoffeeModel> GetCoffeeByIdAsync(int id)
    {
        CoffeeModel coffee = null;

        try
        {
            var request = new RestRequest(ApiConstants.CoffeeEndpoints.GetCoffeeById)
                .AddHeader("Accept", "application/vnd.api+json")
                .AddUrlSegment("id", id);

            var jsonResponse = await RestClient.ExecuteAsync(request).ConfigureAwait(false);

            if (jsonResponse is { IsSuccessful: true, Content: not null })
            {
                coffee = JsonConvert.DeserializeObject<CoffeeModel>(jsonResponse.Content);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"APILOG: {ex.StackTrace}");
        }

        return coffee;
    }
}