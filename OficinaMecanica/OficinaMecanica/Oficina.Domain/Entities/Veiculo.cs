namespace Oficina.Domain.Entities;

using Oficina.Domain.Common;
using Oficina.Domain.Enums;

public class Veiculo : BaseEntity
{
    public Guid ClienteId { get; set; }
    public Cliente Cliente { get; set; } = null!;

    public string Placa { get; set; } = string.Empty;
    public string? Renavam { get; set; }
    public string? Chassi { get; set; }
    public string Marca { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public int? Ano { get; set; }
    public string? Cor { get; set; }
    public TipoVeiculo Tipo { get; set; }
    public decimal? KmAtual { get; set; }
    public string? Observacoes { get; set; }
}