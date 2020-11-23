using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ToDoAPI.Models;

namespace ToDoAPI.Controllers
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
/*
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
        } */

        [HttpGet]
        public IActionResult Get()
        {
            var toDos = Storage.GetAll();
            return Ok(new
            {
                toDos = toDos.toDos,
                count = toDos.count
            });

        }

        [HttpPost]
        //
        public IActionResult Post(AddToDoRequest request)
        {
            var toDo = new ToDo {Title = request.Title, When = request.When};
            var isOk = Storage.Add(toDo);
            return Ok($"Added: {isOk}");
        }
    }
}