using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blazorFagdag.Server.Dto;
using blazorFagdag.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace blazorFagdag.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var client = new RestClient("https://api.met.no/weatherapi/locationforecast/2.0/compact?lat=60.23&lon=5.19&altitude=10");
            var request = new RestRequest();
            
            var response = await client.ExecuteGetAsync<YrData>(request);

            YrData yr = response.Data;
            
            var weatherForecasts = yr.properties.timeseries.Select(timesery => new WeatherForecast
                {
                    Date = timesery.time,
                    TemperatureC = timesery.data.instant.details.air_temperature,
                    Summary = timesery.data.next_1_hours?.summary.symbol_code
                })
                .ToList();
            return weatherForecasts;
        }
        
        
    }
}