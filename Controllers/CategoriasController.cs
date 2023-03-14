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
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly ILogger<CategoriasController> _logger;
        ICategoriaService categoriaService;

        public CategoriasController(ICategoriaService _categoriaService)
        {
            categoriaService = _categoriaService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(categoriaService.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Categoria categoria)
        {
            categoriaService.Save(categoria);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Categoria categoria)
        {
            categoriaService.Update(id, categoria);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            categoriaService.Delete(id);
            return Ok();
        }
    }
}