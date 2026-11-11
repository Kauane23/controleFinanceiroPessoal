using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace controleFinanceiro.Entities
{
    [Table("conta"), PrimaryKey(nameof(Id))]
    public class Conta
    {
        [Column("id_conta")]
        public int Id { get; set; }

        [Column("nome")]
        public string? Nome { get; set; }

        [Column("nome_instituicao")]
        public string? NomeInstituicao { get; set; }

        [Column("tipo")]
        public string Tipo {  get; set; 
        } = string.Empty;

        [Column("saldo_atual")]
        public float SaldoAtual {  get; set; }

        [Column("id_usuario_fk")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;

        public ICollection<Movimentacao> Movimentacoes { get; set; } = new List<Movimentacao>();
    }
}
