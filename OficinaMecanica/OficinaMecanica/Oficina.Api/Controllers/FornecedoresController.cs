using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oficina.Application.DTOs;
using Oficina.Application.services;

namespace Oficina.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FornecedoresController : ControllerBase
    {
        private readonly FornecedorService _service;

        public FornecedoresController(FornecedorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var fornecedores = await _service.ListarAsync();
            return Ok(fornecedores);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var fornecedor = await _service.ObterPorIdAsync(id);
            if (fornecedor == null)
            {
                return NotFound(new { mensagem = "Fornecedor não encontrado." });
            }
            return Ok(fornecedor);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarFornecedorDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var novoFornecedor = await _service.CriarAsync(dto);
            return CreatedAtAction(nameof(ObterPorId), new { id = novoFornecedor.Id }, novoFornecedor);
        }
    }
}