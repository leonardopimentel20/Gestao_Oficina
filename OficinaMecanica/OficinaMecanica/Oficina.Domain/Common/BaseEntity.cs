namespace Oficina.Domain.Common;

public abstract class BaseEntity
{
    public Guid Id { get; protected set; } = Guid.NewGuid();
    public DateTimeOffset CriadoEm { get; protected set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? AtualizadoEm { get; set; }
}