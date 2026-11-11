using System.ComponentModel.DataAnnotations.Schema;

namespace controleFinanceiro.Dtos.Responses
{
    public class ContaResponseDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? NomeInstituicao { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public float SaldoAtual { get; set; }

        public UsuarioResponseDto Usuario { get; set; } = null!;

        public ICollection<MovimentacaoResponseDto> Movimentacoes { get; set; } = [];
    }
}
