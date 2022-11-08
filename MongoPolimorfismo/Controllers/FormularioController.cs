using Microsoft.AspNetCore.Mvc;
using MongoPolimorfismo.Domain.Models;
using MongoPolimorfismo.Domain.Repositories;
using System.Net;

namespace MongoPolimorfismo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormularioController : ControllerBase
    {
        private readonly ILogger<FormularioController> _logger;
        private readonly IFormularioRepository _formularioRepository;

        public FormularioController(ILogger<FormularioController> logger, IFormularioRepository formularioRepository)
        {
            _logger = logger;
            _formularioRepository = formularioRepository;
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Formulario), StatusCodes.Status200OK)]
        public async Task<IActionResult> Salvar([FromBody] Formulario formulario)
        {
            await _formularioRepository.SalvarAsync(formulario);

            return Ok(formulario);
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Formulario), StatusCodes.Status200OK)]
        public async Task<IActionResult> Buscar([FromRoute] string id)
        {
            var formulario = await _formularioRepository.BuscarAsync(x => x.Id == id);
            return Ok(formulario);
        }
    }
}