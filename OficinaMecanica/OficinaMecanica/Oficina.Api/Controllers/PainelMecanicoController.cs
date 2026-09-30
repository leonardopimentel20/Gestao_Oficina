namespace Oficina.Api.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oficina.Persistence.Context;
using Oficina.Application.services;
using System.ComponentModel.DataAnnotations;
using Oficina.Domain.Entities;
using Oficina.Application.DTOs;

[ApiController]
[Route("api/[controller]")]
public class PainelMecanicoController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly ProdutoService _produtoService;

    // Apenas UM construtor limpo que injeta as duas dependências corretamente
    public PainelMecanicoController(AppDbContext context, ProdutoService produtoService)
    {
        _context = context;
        _produtoService = produtoService;
    }

    // GET: api/painelmecanico/produtos?busca=oleo
    [HttpGet("produtos")]
    public async Task<IActionResult> BuscarProdutosEstoque([FromQuery] string? busca)
    {
        try
        {
            var produtosDto = await _produtoService.ListarProdutosAsync();

            if (!string.IsNullOrWhiteSpace(busca))
            {
                produtosDto = produtosDto
                    .Where(p => p.Nome.Contains(busca, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            var resultado = produtosDto.Take(20).Select(p => new
            {
                id = p.Id,
                nome = p.Nome,
                quantidade = p.Quantidade,
                preco = p.PrecoVenda,
                localizacao = "Almoxarifado Central"
            });

            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro ao consultar stock", details = ex.Message });
        }
    }

    // POST: api/painelmecanico/orcamento-rapido
    [HttpPost("orcamento-rapido")]
    public async Task<IActionResult> CriarOrcamentoRapido([FromBody] OrcamentoRapidoDto dto)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(dto.Placa) || string.IsNullOrWhiteSpace(dto.DescricaoServico))
            {
                return BadRequest(new { message = "A placa e a descrição do serviço são obrigatórias." });
            }

            var novoOrcamento = new OrcamentoRapidoEntity
            {
                Placa = dto.Placa.ToUpper(),
                DescricaoServico = dto.DescricaoServico,
                ValorEstimado = dto.ValorEstimado,
                Status = "Pendente",
                DataCriacao = DateTime.UtcNow
            };

            _context.Set<OrcamentoRapidoEntity>().Add(novoOrcamento);
            await _context.SaveChangesAsync();

            return Ok(new { success = true, message = "Pré-orçamento gerado e enviado para a gestão com sucesso!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro ao gravar orçamento", details = ex.Message });
        }
    }

    // GET: api/painelmecanico/orcamentos-pendentes
    [HttpGet("orcamentos-pendentes")]
    public async Task<IActionResult> ObterOrcamentosPendentes()
    {
        try
        {
            var pendentes = await _context.Set<OrcamentoRapidoEntity>()
                .Where(o => o.Status == "Pendente")
                .OrderByDescending(o => o.DataCriacao)
                .Select(o => new
                {
                    id = o.Id,
                    placa = o.Placa,
                    descricaoServico = o.DescricaoServico,
                    valorEstimado = o.ValorEstimado,
                    dataCriacao = o.DataCriacao
                })
                .ToListAsync();

            return Ok(pendentes);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro ao buscar orçamentos pendentes", details = ex.Message });
        }
    }

    // POST: api/painelmecanico/aprovar/{id}
    [HttpPost("aprovar/{id}")]
    public async Task<IActionResult> AprovarOrcamento(int id)
    {
        try
        {
            var orcamento = await _context.Set<OrcamentoRapidoEntity>().FindAsync(id);
            if (orcamento == null)
            {
                return NotFound(new { message = "Orçamento não encontrado." });
            }

            orcamento.Status = "Aprovado";
            await _context.SaveChangesAsync();

            return Ok(new { success = true, message = "Orçamento aprovado com sucesso!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro ao aprovar orçamento", details = ex.Message });
        }
    }

    // GET: api/painelmecanico/veiculo/ABC1234
    [HttpGet("veiculo/{termo}")]
    public async Task<IActionResult> BuscarVeiculoPorPlacaOuChassi(string termo)
    {
        try
        {
            var veiculo = await _context.Set<Veiculo>()
                .Include(v => v.Cliente)
                .FirstOrDefaultAsync(v => v.Placa.ToUpper() == termo.ToUpper() || v.Chassi.ToUpper() == termo.ToUpper());

            if (veiculo == null)
            {
                return NotFound(new { message = "Veículo não encontrado. Verifique a placa ou chassis." });
            }

            return Ok(new
            {
                id = veiculo.Id, // Se o ID do veículo for Guid ou int, o JSON devolve de forma transparente
                placa = veiculo.Placa,
                chassi = veiculo.Chassi,
                marca = veiculo.Marca,
                modelo = veiculo.Modelo,
                ano = veiculo.Ano,
                clienteId = veiculo.ClienteId,
                clienteNome = veiculo.Cliente != null ? veiculo.Cliente.Nome : "Cliente não vinculado"
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro ao buscar veículo", details = ex.Message });
        }
    }

    // POST: api/painelmecanico/abrir-os
    // POST: api/painelmecanico/abrir-os
    [HttpPost("abrir-os")]
    public async Task<IActionResult> AbrirOrdemServicoMecanico([FromBody] AbrirOsMecanicoDto dto)
    {
        try
        {
            if (dto.VeiculoId == Guid.Empty || string.IsNullOrWhiteSpace(dto.DefeitoRelatado))
            {
                return BadRequest(new { message = "O veículo e a descrição do defeito/sintoma são obrigatórios." });
            }

            var novaOS = new OrdemServico
            {
                ClienteId = dto.ClienteId,
                VeiculoId = dto.VeiculoId,
                DefeitoRelatado = dto.DefeitoRelatado,
                Status = "Aberta",
                DataAbertura = DateTime.UtcNow,
                Itens = dto.Itens.Select(i => new OrdemServicoItem
                {
                    Tipo = i.Tipo,
                    // Utilize aqui o nome real da propriedade que existe na vossa classe OrdemServicoItem (ex: Descricao ou Nome)
                    // Se a propriedade na vossa entidade se chamar de outra forma, ajuste esta linha:
                    Quantidade = (int) i.Quantidade,
                    ValorUnitario = i.ValorUnitario
                }).ToList()
            };

            novaOS.ValorTotal = (int)novaOS.Itens.Sum(i => i.Quantidade * i.ValorUnitario);

            _context.Set<OrdemServico>().Add(novaOS);
            await _context.SaveChangesAsync();

            return Ok(new { success = true, message = "Ordem de Serviço aberta com sucesso no pátio!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro ao abrir Ordem de Serviço", details = ex.Message });
        }
    }
}

public class OrcamentoRapidoDto
{
    [Required]
    public string Placa { get; set; } = string.Empty;
    [Required]
    public string DescricaoServico { get; set; } = string.Empty;
    public decimal ValorEstimado { get; set; }
}