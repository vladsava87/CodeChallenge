using RestSharp;

namespace Api;

public abstract  class ApiClient
{
    protected readonly IRestClient RestClient;

    protected ApiClient()
    {
        var options = new RestClientOptions($"{ApiConstants.Host}") {
            RemoteCertificateValidationCallback = (_, _, _, _) => true
        };
            
        RestClient = new RestClient(options);
    }
}