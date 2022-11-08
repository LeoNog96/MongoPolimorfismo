using Microsoft.AspNetCore.Mvc;
using MongoPolimorfismo.Domain.Models;
using MongoPolimorfismo.Domain.Repositories;

namespace MongoPolimorfismo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampoController : ControllerBase
    {
        private readonly ILogger<CampoController> _logger;
        private readonly IFormularioRepository _formularioRepository;

        public CampoController(ILogger<CampoController> logger, IFormularioRepository formularioRepository)
        {
            _logger = logger;
            _formularioRepository = formularioRepository;
        }

        [HttpPost("adicionar/formulario/{idFormulario}/bloco/{idBloco}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Formulario), StatusCodes.Status200OK)]
        public async Task<IActionResult> Salvar([FromBody] Campo campo, [FromRoute] string idFormulario, [FromRoute] string idBloco)
        {
            var formulario = await _formularioRepository.BuscarAsync(x => x.Id == idFormulario);

            var bloco = formulario.Blocos.Where(x => x.Id == idBloco).FirstOrDefault();

            if (bloco.Campos == null) bloco.Campos = new List<Campo>(1);

            bloco.Campos = bloco.Campos.Append(campo);

            await _formularioRepository.AlterarAsync(x => x.Id == idFormulario, formulario);

            return Ok(formulario);
        }

        [HttpDelete("adicionar/formulario/{idFormulario}/bloco/{idBloco}/campo/{idCampo}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Formulario), StatusCodes.Status200OK)]
        public async Task<IActionResult> Salvar([FromRoute] string idCampo, [FromRoute] string idFormulario, [FromRoute] string idBloco)
        {
            var formulario = await _formularioRepository.BuscarAsync(x => x.Id == idFormulario);

            var bloco = formulario.Blocos.Where(x => x.Id == idBloco).FirstOrDefault();

            bloco.Campos = bloco.Campos.Where(x => x.Id != idCampo);

            await _formularioRepository.AlterarAsync(x => x.Id == idFormulario, formulario);

            return Ok(formulario);
        }
    }
}
