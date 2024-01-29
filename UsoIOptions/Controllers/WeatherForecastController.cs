using IOptions.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;


namespace IOptions.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Ensolarado", "Nublado", "Chuvoso", "Tempestade", "Neve", "Nevoeiro"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IOptionsMonitor<WeatherOptions> _options;

        public WeatherForecastController(IOptionsMonitor<WeatherOptions> options, ILogger<WeatherForecastController> logger)
        {
            _options = options;
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var fixo = new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now),
                TemperatureC = _options.CurrentValue.Temperature,
                Summary = "Chuvoso"
            };

            var weatherList = new List<WeatherForecast> { fixo };

            Random random = new Random();

            var randomList = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = random.Next(-20, 40),
                Summary = Summaries[random.Next(Summaries.Length)]
            })
            .ToArray();

            return _options.CurrentValue.UseFixedValue ? (weatherList) : (randomList);

        }
    }
}
