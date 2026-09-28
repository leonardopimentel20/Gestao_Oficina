namespace Oficina.Api.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oficina.Application.Services;
using System.Security.Claims;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class VeiculosController : ControllerBase
{
    private readonly VeiculoService _veiculoService;

    public VeiculosController(VeiculoService veiculoService)
    {
        _veiculoService = veiculoService;
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
    public async Task<IActionResult> Criar([FromBody] CriarVeiculoDto dto)
    {
        try
        {
            var unidadeId = ObterUnidadeIdLogada();
            var id = await _veiculoService.RegistarVeiculoAsync(dto, unidadeId);
            return CreatedAtAction(nameof(ObterPorId), new { id = id }, new { id = id });
        }
        catch (UnauthorizedAccessException ex)
        {
            return Forbid();
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
        var veiculo = await _veiculoService.ObterVeiculoSeguroAsync(id, unidadeId);
        if (veiculo == null)
            return NotFound();
            
        return Ok(veiculo);
    }

    [HttpGet]
    public async Task<IActionResult> ObterTodos()
    {
        var unidadeId = ObterUnidadeIdLogada();
        var veiculos = await _veiculoService.ObterTodosSeguroAsync(unidadeId);
        return Ok(veiculos);
    }
}
