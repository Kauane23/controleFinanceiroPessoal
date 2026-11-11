using System.ComponentModel.DataAnnotations.Schema;

namespace controleFinanceiro.Dtos.Responses
{
    public class MovimentacaoResponseDto
    {
        public int Id { get; set; }
        public float Valor {  get; set; }
        public DateOnly DataMovimentacao { get; set; }
        public string? Descricao { get; set; }

        public ContaResponseDto Conta { get; set; } = null!;

        public CategoriaResponseDto Categoria { get; set; } = null!;
    } 
}
