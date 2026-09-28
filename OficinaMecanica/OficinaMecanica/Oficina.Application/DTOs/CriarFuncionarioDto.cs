using System.ComponentModel.DataAnnotations;

namespace Oficina.Application.DTOs
{
    public class CriarFuncionarioDto
    {
        [Required(ErrorMessage = "O ID da unidade é obrigatório.")]
        public Guid UnidadeId { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(150, ErrorMessage = "O nome deve ter no máximo 150 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [StringLength(20, ErrorMessage = "O documento deve ter no máximo 20 caracteres.")]
        public string? Documento { get; set; }

        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        [StringLength(100)]
        public string? Email { get; set; }

        [StringLength(20)]
        public string? Telefone { get; set; }

        [Range(0, 100, ErrorMessage = "O percentual de comissão deve estar entre 0 e 100.")]
        public decimal PercentualComissaoPadrao { get; set; }
    }
}