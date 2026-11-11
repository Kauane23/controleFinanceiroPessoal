using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace controleFinanceiro.Entities
{
    [Table("categoria"), PrimaryKey(nameof(Id))]
    public class Categoria
    {
        [Column("id_categoria")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; } = string.Empty;

        [Column("tipo")]
        public string Tipo { get; set; } = string.Empty;

        public ICollection<Movimentacao> Movimentacoes { get; set; }
    = new List<Movimentacao>();
    }
}
