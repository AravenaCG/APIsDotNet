using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIs_.NET.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIs_.NET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController:ControllerBase
    {
            private readonly ILogger<WeatherForecastController> _logger;

        IHelloWorldService helloWorldService;

        public HelloWorldController(IHelloWorldService helloWorld, ILogger<WeatherForecastController> logger){
            _logger = logger;
            helloWorldService = helloWorld;
        }    

    [HttpGet()]
        public IActionResult Get(){
            _logger.LogInformation("Se retorna el mensaje hola mundo");
            return Ok(helloWorldService.GetHelloWorld());
        }
    }
}