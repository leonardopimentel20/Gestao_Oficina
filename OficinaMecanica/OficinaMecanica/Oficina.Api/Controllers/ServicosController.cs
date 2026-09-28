using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oficina.Application.DTOs;
using Oficina.Application.services;

namespace Oficina.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ServicosController : ControllerBase
    {
        private readonly ServicoService _service;

        public ServicosController(ServicoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var servicos = await _service.ListarAsync();
            return Ok(servicos);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var servico = await _service.ObterPorIdAsync(id);
            if (servico == null)
            {
                return NotFound(new { mensagem = "Serviço não encontrado." });
            }
            return Ok(servico);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarServicoDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var novoServico = await _service.CriarAsync(dto);
            return CreatedAtAction(nameof(ObterPorId), new { id = novoServico.Id }, novoServico);
        }
    }
}