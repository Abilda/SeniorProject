using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RestaInitial.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private string _accessToken = String.Empty; 
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        private async Task<string> GetToken()
        {
            if (string.IsNullOrEmpty(_accessToken))
            {
                using (var client = new HttpClient())
                {
                    var discoveryDocumetnResponse = await client.GetDiscoveryDocumentAsync("https://localhost:1001/");
                    if (discoveryDocumetnResponse.IsError)
                        throw new Exception();
                    var tokenResponse = await client.RequestClientCredentialsTokenAsync(
                        new ClientCredentialsTokenRequest
                        {
                            Address = discoveryDocumetnResponse.TokenEndpoint,
                            ClientId = "ClientId",
                            ClientSecret = "ClientSecret",
                            Scope = "fullAccess"
                        });
                    _accessToken = tokenResponse.AccessToken;
                }
            }
            return _accessToken;
        }
        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            using (var client = new HttpClient())
            {
                client.SetBearerToken(await GetToken());
                var response = await client.GetAsync("https://localhost:44386/");
                var temp = response.Content;
            }
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
    
        }
    }
}
