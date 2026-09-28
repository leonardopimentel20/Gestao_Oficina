using System.ComponentModel.DataAnnotations;

namespace Oficina.Application.DTOs
{
    public class CriarOrdemServicoDto
    {
        [Required(ErrorMessage = "O cliente é obrigatório.")]
        public Guid ClienteId { get; set; }

        [Required(ErrorMessage = "O veículo é obrigatório.")]
        public Guid VeiculoId { get; set; }

        public Guid? FuncionarioId { get; set; }

        [StringLength(1000, ErrorMessage = "O defeito relatado deve ter no máximo 1000 caracteres.")]
        public string? DefeitoRelatado { get; set; }
    }
}