using System.ComponentModel.DataAnnotations;

namespace Oficina.Application.DTOs
{
    public class CriarProdutoDto
    {
        [Required(ErrorMessage = "O código do produto é obrigatório.")]
        public string Codigo { get; set; } = string.Empty;

        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres.")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "A unidade de medida é obrigatória.")]
        public string UnidadeMedida { get; set; } = string.Empty;

        [Required(ErrorMessage = "O preço de venda é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço de venda deve ser maior que zero.")]
        public decimal PrecoVenda { get; set; }

        [Required(ErrorMessage = "O custo médio é obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "O custo médio não pode ser negativo.")]
        public decimal CustoMedio { get; set; }

        [Required(ErrorMessage = "A quantidade em stock é obrigatória.")]
[Range(0, int.MaxValue, ErrorMessage = "A quantidade não pode ser negativa.")]
public int Quantidade { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "O estoque mínimo não pode ser negativo.")]
        public decimal EstoqueMinimo { get; set; }

        public Guid? CategoriaProdutoId { get; set; }
    }
}