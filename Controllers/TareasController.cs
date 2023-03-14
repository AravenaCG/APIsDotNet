using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIs_.NET.Services;
using Entity_Framework_Platzi.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIs_.NET.Controllers
{
    [ApiController]
    [Route("[api/controller]")]
    public class TareasController : ControllerBase
    {
        private readonly ILogger<TareasController> _logger;
        ITareasService tareaService;

        public TareasController(ITareasService _tareaService)
        {
            tareaService = _tareaService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(tareaService.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Tarea tarea)
        {
            tareaService.Save(tarea);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Tarea tarea)
        {
            tareaService.Update(id, tarea);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            tareaService.Delete(id);
            return Ok();
        }


    }
}