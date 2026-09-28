using System.ComponentModel.DataAnnotations;

namespace Oficina.Application.DTOs
{
    public class CriarServicoDto
    {
        [Required(ErrorMessage = "O código do serviço é obrigatório.")]
        [StringLength(20, ErrorMessage = "O código deve ter no máximo 20 caracteres.")]
        public string Codigo { get; set; } = string.Empty;

        [Required(ErrorMessage = "O nome do serviço é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres.")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "O preço de venda é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal PrecoPadrao { get; set; }

        public Guid? CategoriaServicoId { get; set; }
    }
}