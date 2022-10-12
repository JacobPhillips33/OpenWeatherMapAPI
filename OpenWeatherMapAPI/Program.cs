using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using static System.Net.WebRequestMethods;

var client = new HttpClient();

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

string api_key = config.GetConnectionString("WeatherAPIKey");

Console.WriteLine("This application will provide weather details for a particular city.");
Console.WriteLine();
Console.Write("Please enter a city: ");
var city_name = Console.ReadLine();
Console.WriteLine();

var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={city_name}&appid={api_key}&units=imperial";

var weatherResponse = client.GetStringAsync(weatherURL).Result;

var weatherParse = JObject.Parse(weatherResponse);

var temp = weatherParse["main"]["temp"];
var pressure = weatherParse["main"]["pressure"];
var humidity = weatherParse["main"]["humidity"];
var windSpeed = weatherParse["wind"]["speed"];
var description = weatherParse["weather"][0]["description"];
var cityUpper = city_name.ToUpper();

Console.WriteLine("********************************************************************");
Console.WriteLine($"                    {cityUpper} WEATHER");
Console.WriteLine("********************************************************************");
Console.WriteLine();
Console.WriteLine($"Temperature: {temp} degrees F");
Console.WriteLine($"Pressure:    {pressure}");
Console.WriteLine($"Humidity:    {humidity} percent");
Console.WriteLine($"Wind Speed:  {windSpeed} mph");
Console.WriteLine($"Description: {description}");
Console.WriteLine();
Console.WriteLine("********************************************************************");







