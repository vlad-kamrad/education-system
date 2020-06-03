using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDU.Application.Boundaries.GetUser;
using EDU.Application.UseCases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EDU.WebApi.Controllers
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
        public async Task<IEnumerable> Get(
           /* [FromServices] IGetUserUseCase getUserUseCase,
            [FromServices] GetUserPresenter getUserPresenter  */
        ) {

            /*var input = new GetUserInput(1);
            await getUserUseCase.Execute(input);
            return getUserPresenter.ViewModel;*/

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
