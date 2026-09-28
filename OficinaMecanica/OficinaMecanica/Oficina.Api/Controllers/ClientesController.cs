namespace Oficina.Api.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oficina.Application.DTOs;
using Oficina.Application.Services;
using System.Security.Claims;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly ClienteService _clienteService;

    public ClientesController(ClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    private Guid ObterUnidadeIdLogada()
    {
        var claim = User.FindFirst("UnidadeId")?.Value;
        if (Guid.TryParse(claim, out Guid unidadeId))
        {
            return unidadeId;
        }
        throw new UnauthorizedAccessException("Usuário sem UnidadeId válida no token.");
    }

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] CriarClienteDto dto)
    {
        try
        {
            var unidadeId = ObterUnidadeIdLogada();
            var id = await _clienteService.RegistarClienteAsync(dto, unidadeId);
            return CreatedAtAction(nameof(ObterPorId), new { id = id }, new { id = id });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterPorId(Guid id)
    {
        var unidadeId = ObterUnidadeIdLogada();
        var cliente = await _clienteService.ObterClienteSeguroAsync(id, unidadeId);
        if (cliente == null)
            return NotFound();
            
        return Ok(cliente);
    }

    [HttpGet]
    public async Task<IActionResult> ObterTodos()
    {
        var unidadeId = ObterUnidadeIdLogada();
        var clientes = await _clienteService.ObterTodosSeguroAsync(unidadeId);
        return Ok(clientes);
    }
}
