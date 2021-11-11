using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blazorFagdag.Server.Dto;
using blazorFagdag.Shared;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace blazorFagdag.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get(double lat, double lon)
        {
            var latString = lat.ToString().Replace(',', '.');
            var lonString = lon.ToString().Replace(',', '.');
            var client = new RestClient($"https://api.met.no/weatherapi/locationforecast/2.0/compact?lat={latString}&lon={lonString}");
            var request = new RestRequest();
            
            var response = await client.ExecuteGetAsync<YrData>(request);

            YrData yr = response.Data;
            
            var weatherForecasts = yr.properties.timeseries.Select(timesery => new WeatherForecast
            {
                Date = timesery.time,
                TemperatureC = timesery.data.instant.details.air_temperature,
                Summary = timesery.data.next_1_hours?.summary.symbol_code
            }).ToList();
            
            return weatherForecasts;
        }
    }
}