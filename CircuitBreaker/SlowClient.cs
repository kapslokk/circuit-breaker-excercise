using Polly.CircuitBreaker;

namespace CircuitBreaker;

public class SlowClient
{
    private HttpClient _httpClient;


    public SlowClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetSlow()
    {
        var x = await _httpClient.GetAsync("/Slow");

        return await x.Content.ReadAsStringAsync();
    }
}