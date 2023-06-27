using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OpenApi.Models.SettingModels;

namespace OpenApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly PositionOptions _options;


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IOptions<PositionOptions> options)
        {
            _logger = logger;
            _options = options.Value;
        }

        [HttpGet]
        [Route("get")]
        public IEnumerable<WeatherForecast> Get()
        {
            var test = "";

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("getName")]
        public string GetName()
        {
            return _options.Name;
        }

        [HttpGet]
        [Route("getTitle")]
        public string GetTitle()
        {
            return _options.Title;
        }
    }
}
