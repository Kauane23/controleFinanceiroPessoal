using System.ComponentModel.DataAnnotations;

namespace controleFinanceiro.Dtos
{
    public class CategoriaDto
    {
        [Required(ErrorMessage = "O nome da categoria é obrigatório.")]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O tipo da categoria é obrigatório.")]
        [StringLength(100)]
        public string Tipo { get; set; } = string.Empty;

    }
}
