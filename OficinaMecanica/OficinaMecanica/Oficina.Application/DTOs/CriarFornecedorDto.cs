using System.ComponentModel.DataAnnotations;

namespace Oficina.Application.DTOs
{
    public class CriarFornecedorDto
    {
        [Required(ErrorMessage = "O ID da unidade é obrigatório.")]
        public Guid UnidadeId { get; set; }

        [Required(ErrorMessage = "A razão social é obrigatória.")]
        [StringLength(150, ErrorMessage = "A razão social deve ter no máximo 150 caracteres.")]
        public string RazaoSocial { get; set; } = string.Empty;

        [StringLength(150, ErrorMessage = "O nome fantasia deve ter no máximo 150 caracteres.")]
        public string? NomeFantasia { get; set; }

        [StringLength(20, ErrorMessage = "O CNPJ deve ter no máximo 20 caracteres.")]
        public string? Cnpj { get; set; }

        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        [StringLength(100)]
        public string? Email { get; set; }

        [StringLength(20)]
        public string? Telefone { get; set; }
    }
}