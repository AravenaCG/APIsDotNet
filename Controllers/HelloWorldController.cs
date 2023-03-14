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
        IHelloWorldService helloWorldService;

        public HelloWorldController(IHelloWorldService helloWorld){
            helloWorldService = helloWorld;
        }    


        public IActionResult Get(){
            return Ok(helloWorldService.GetHelloWorld());
        }
    }
}