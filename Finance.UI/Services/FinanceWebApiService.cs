using Microsoft.Extensions.Options;

namespace Finance.UI.Services;

public class FinanceWebApiService
{
    public HttpClient HttpClient { get; init; }
    private readonly ApiConfiguration _apiConfiguration;

    public FinanceWebApiService(IOptions<ApiConfiguration> apiConfiguration, HttpClient httpClient)
    {
        _apiConfiguration = apiConfiguration.Value;
        HttpClient = httpClient;
        HttpClient.BaseAddress = new Uri(_apiConfiguration.Uri + _apiConfiguration.Part);
    }
}
