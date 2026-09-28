namespace Oficina.Domain.Entities;

using Oficina.Domain.Common;

public class OrdemServico : BaseEntity
{
    public Guid ClienteId { get; set; }
    public Cliente? Cliente { get; set; }

    public Guid VeiculoId { get; set; }
    public Veiculo? Veiculo { get; set; }

    public Guid? FuncionarioId { get; set; }
    public Funcionario? Funcionario { get; set; }

    public string Status { get; set; } = "Aberta"; // Aberta, EmAndamento, Concluida, Cancelada
    public string? DefeitoRelatado { get; set; }
    public string? LaudoTecnico { get; set; }
    public decimal ValorTotal { get; set; }
    public DateTime DataAbertura { get; set; } = DateTime.UtcNow;
    public DateTime? DataConclusao { get; set; }

    public ICollection<OrdemServicoItem> Itens { get; set; } = new List<OrdemServicoItem>();
}