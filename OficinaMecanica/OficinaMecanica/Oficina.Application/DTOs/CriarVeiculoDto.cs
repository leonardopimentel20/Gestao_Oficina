namespace Oficina.Application.DTOs;

public class CriarVeiculoDto
{
    public Guid ClienteId { get; set; }
    public string Placa { get; set; } = string.Empty;
    public string? Renavam { get; set; }
    public string? Chassi { get; set; }
    public string Marca { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public int Ano { get; set; }
    public string? Observacoes { get; set; }
}