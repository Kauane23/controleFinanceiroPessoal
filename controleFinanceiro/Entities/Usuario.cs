using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace controleFinanceiro.Entities
{
    [Table("usuario"), PrimaryKey(nameof(Id))]
    public class Usuario
    {
        [Column("id_usuario")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; } = string.Empty;

        [Column("email")]
        public string Email { get; set; } = string.Empty;

        [Column("cpf")]
        public string Cpf {  get; set; } = string.Empty;

        [Column("telefone")]
        public string? Telefone {  get; set; } = string.Empty;

        [Column("senha")]
        public string Senha { get; set; } = string.Empty;

        public ICollection<Conta> Contas { get; set; } = new List<Conta>();
    }
}
