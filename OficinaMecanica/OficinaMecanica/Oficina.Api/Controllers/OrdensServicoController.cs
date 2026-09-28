using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oficina.Application.DTOs;
using Oficina.Application.services;

namespace Oficina.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrdensServicoController : ControllerBase
    {
        private readonly OrdemServicoService _service;

        public OrdensServicoController(OrdemServicoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var osList = await _service.ListarAsync();
            return Ok(osList);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var os = await _service.ObterPorIdAsync(id);
            if (os == null)
            {
                return NotFound(new { mensagem = "Ordem de Serviço não encontrada." });
            }
            return Ok(os);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarOrdemServicoDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var novaOs = await _service.CriarAsync(dto);
            return CreatedAtAction(nameof(ObterPorId), new { id = novaOs.Id }, novaOs);
        }
    }
}