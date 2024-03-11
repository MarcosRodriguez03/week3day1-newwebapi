using Microsoft.AspNetCore.Mvc;
using week3day1_newwebapi.Services;

//our root file. itss a way for c# to organize our code
//week3day1-newwebapi = parent folder
// controllers = is our Controller folder
namespace week3day1_newwebapi.Controllers;

//apiController = is a AspNetCore.Mvc special attribute that marks this class as a API controller 
[ApiController]
//route = is the route to this controller 
[Route("[controller]")]

//the name of our class , weatherForeCastController
//: controllerBase = inherits from aspnetcore.mvt it provides set of common functions like get post etc
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    // this is a class
    private readonly ILogger<WeatherForecastController> _logger;

    private readonly WeatherForecastService _data;

    // constructor = allows you to set up intial values or configurations for an object when it is created. this ensures that the object starts in a valid and consistent state
    //for example , a bike factory when the frame and wheels are made  , there is a station that takes care of putting them together. thats the constructor

    //were in injecting WeatherForecastService into the consturctor, controller is able to get the necessary services from our servies
    public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherForecastService data)
    {
        _logger = logger;
        _data = data;
    }

    // this would be read in our crud functinos
    [HttpGet(Name = "GetWeatherForecast")]

    //iEnumeraboe = a collection of object that can be enumerated(iterated) one at a time 
    public IEnumerable<WeatherForecast> GetWeather()
    {
        return _data.GetWeather(Summaries);
    }
}
