namespace controleFinanceiro.Dtos.Responses
{
    public class MovimentacaoResponseDto
    {
        public int Id { get; set; }
        public float Valor { get; set; }
        public DateOnly DataMovimentacao { get; set; }
        public string? Descricao { get; set; }

        public int ContaId { get; set; }
        public string? ContaNome { get; set; }

        public int CategoriaId { get; set; }
        public string CategoriaNome { get; set; } = string.Empty;
        public string CategoriaTipo { get; set; } = string.Empty;
    }
}