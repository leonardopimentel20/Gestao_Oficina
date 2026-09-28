using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oficina.Application.DTOs;
using Oficina.Application.services;

namespace Oficina.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/ordens-servico/{ordemServicoId:guid}/itens")]
    public class OrdemServicoItensController : ControllerBase
    {
        private readonly OrdemServicoService _ordemServicoService;

        public OrdemServicoItensController(OrdemServicoService ordemServicoService)
        {
            _ordemServicoService = ordemServicoService;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarItem(Guid ordemServicoId, [FromBody] AdicionarItemOsDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var itemCriado = await _ordemServicoService.AdicionarItemAsync(ordemServicoId, dto);
                return Ok(itemCriado);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}