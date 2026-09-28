using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oficina.Application.DTOs;
using Oficina.Application.services;

namespace Oficina.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionariosController : ControllerBase
    {
        private readonly FuncionarioService _service;

        public FuncionariosController(FuncionarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var funcionarios = await _service.ListarAsync();
            return Ok(funcionarios);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var funcionario = await _service.ObterPorIdAsync(id);
            if (funcionario == null)
            {
                return NotFound(new { mensagem = "Funcionário não encontrado." });
            }
            return Ok(funcionario);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarFuncionarioDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var novoFuncionario = await _service.CriarAsync(dto);
            return CreatedAtAction(nameof(ObterPorId), new { id = novoFuncionario.Id }, novoFuncionario);
        }
    }
}