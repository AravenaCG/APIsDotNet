using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIs_.NET.Services;
using Entity_Framework_Platzi;
using Microsoft.AspNetCore.Mvc;

namespace APIs_.NET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorldController:ControllerBase
    {
            private readonly ILogger<WeatherForecastController> _logger;

        IHelloWorldService helloWorldService;

        TareasContext dbcontext;

        public HelloWorldController(IHelloWorldService helloWorld, ILogger<WeatherForecastController> logger, TareasContext db){
            _logger = logger;
            dbcontext = db;
            helloWorldService = helloWorld;
        }    

    [HttpGet()]
        public IActionResult Get(){
            _logger.LogInformation("Se retorna el mensaje hola mundo");
            return Ok(helloWorldService.GetHelloWorld());
        }

        [HttpGet]
        [Route("createdb")]
        public IActionResult CreateDatabase(){
            dbcontext.Database.EnsureCreated();
            return Ok();
        }
    }
}