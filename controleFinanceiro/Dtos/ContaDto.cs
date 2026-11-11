using System.ComponentModel.DataAnnotations;

namespace controleFinanceiro.Dtos
{
    public class ContaDto
    {
        [StringLength(100)]
        public string? Nome { get; set; }

        [StringLength(150)]
        public string? NomeInstituicao { get; set; }

        [Required(ErrorMessage = "O tipo da conta é obrigatório.")]
        [StringLength(100)]
        public string Tipo { get; set; } = string.Empty;

        [Required(ErrorMessage = "O saldo é obrigatório.")]
        public float? SaldoAtual { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Informe um usuário válido.")]
        public int UsuarioId { get; set; }
    }
}
