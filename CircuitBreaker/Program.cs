// See https://aka.ms/new-console-template for more information

using CircuitBreaker;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();


serviceCollection.AddHttpClient<SlowClient>(x =>
{
    x.BaseAddress = new Uri("http://localhost:5204/Slow");
});

serviceCollection.AddHttpClient<WeatherApiClient>(x =>
{
    x.BaseAddress = new Uri("http://localhost:5051/WeatherForecast");
});

var sp = serviceCollection.BuildServiceProvider();

var slowClient = sp.GetRequiredService<SlowClient>();
var weatherClient = sp.GetRequiredService<WeatherApiClient>();

while (true)
{
    Console.WriteLine(await slowClient.GetSlow());
    Console.WriteLine(await weatherClient.GetWeather());
    Console.WriteLine();
    Console.WriteLine();
    await Task.Delay(100);
}