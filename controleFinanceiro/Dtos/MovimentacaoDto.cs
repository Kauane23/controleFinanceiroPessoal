using System.ComponentModel.DataAnnotations;

namespace controleFinanceiro.Dtos
{
    public class MovimentacaoDto
    {
        [Required(ErrorMessage = "O valor é obrigatório.")]
        [Range(0.01, float.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
        public float? Valor { get; set; }

        [Required(ErrorMessage = "A data da movimentação é obrigatória.")]
        public DateOnly? DataMovimentacao { get; set; }

        public string? Descricao { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Informe uma conta válida.")]
        public int ContaId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Informe uma categoria válida.")]
        public int CategoriaId { get; set; }
    }
}
