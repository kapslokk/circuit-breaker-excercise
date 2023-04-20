namespace CircuitBreaker;

public class WeatherApiClient
{
    private readonly HttpClient _httpClient;


    public WeatherApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetWeather()
    {
        var x = await _httpClient.GetAsync("/WeatherForecast");
        return await x.Content.ReadAsStringAsync();
    }
}