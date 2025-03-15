using System.Text.Json;

class Program
{
    static async Task Main()
    {
        Task openWeatherTask = openWeather();
        Task weatherApiTask = weatherApi();

        await Task.WhenAll(openWeatherTask, weatherApiTask);
    }

    static async Task openWeather()
    {
        var httpClient = new HttpClient();
        string apiKey = "7b4d82269f649f025909a1874775fb75";
        var weatherData = await httpClient.GetStringAsync($"https://api.openweathermap.org/data/2.5/weather?lat=46.48&lon=30.71&units=metric&appid={apiKey}");
        using var jsonDocument = JsonDocument.Parse(weatherData);
        double temperature = jsonDocument.RootElement.GetProperty("main").GetProperty("temp").GetDouble();
        Console.WriteLine($"OpenWeather: {temperature}C");
    }
    static async Task weatherApi()
    {
        var httpClient = new HttpClient();
        string apiKey = "a9991f890ee14e7592e155022251203";
        var weatherData = await httpClient.GetStringAsync($"https://api.weatherapi.com/v1/current.json?key={apiKey}&q=Odesa");
        using var jsonDocument = JsonDocument.Parse(weatherData);
        double temperature = jsonDocument.RootElement.GetProperty("current").GetProperty("temp_c").GetDouble();
        Console.WriteLine($"WeatherApi: {temperature}C");
    }
}