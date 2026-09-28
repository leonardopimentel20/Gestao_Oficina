namespace Oficina.Domain.Entities;

using Oficina.Domain.Common;

public class Usuario : BaseEntity
{
    public Guid UnidadeId { get; set; }
    public Unidade Unidade { get; set; } = null!;
    public Guid? FuncionarioId { get; set; }
    public Funcionario? Funcionario { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string SenhaHash { get; set; } = string.Empty;
    public bool Ativo { get; set; } = true;
    public DateTimeOffset? UltimoLoginEm { get; set; }
}
