using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace controleFinanceiro.Entities
{
    [Table("movimentacao"), PrimaryKey(nameof(Id))]
    public class Movimentacao
    {
        [Column("id_movimentacao")]
        public int Id { get; set; }

        [Column("valor")]
        public float Valor { get; set; }

        [Column("data_movimentacao")]
        public DateOnly DataMovimentacao { get; set; }

        [Column("descricao")]
        public string? Descricao { get; set; }

        [Column("id_conta_fk")]
        public int ContaId { get; set; }
        public Conta Conta { get; set; } = null!;

        [Column("id_categoria_fk")]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; } = null!;
    }
}
