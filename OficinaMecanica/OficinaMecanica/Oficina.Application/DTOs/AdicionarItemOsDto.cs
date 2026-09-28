using System.ComponentModel.DataAnnotations;

namespace Oficina.Application.DTOs
{
    public class AdicionarItemOsDto
    {
        public Guid? ProdutoId { get; set; }
        public Guid? ServicoId { get; set; }

        [Required(ErrorMessage = "A quantidade é obrigatória.")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser no mínimo 1.")]
        public int Quantidade { get; set; } = 1;

        [Required(ErrorMessage = "O valor unitário é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor unitário deve ser maior que zero.")]
        public decimal ValorUnitario { get; set; }

        [Required(ErrorMessage = "O tipo do item é obrigatório.")]
        public string Tipo { get; set; } = "Produto"; // "Produto" ou "Servico"
    }
}