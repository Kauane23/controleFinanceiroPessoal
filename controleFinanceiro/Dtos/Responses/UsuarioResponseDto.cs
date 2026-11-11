using System.ComponentModel.DataAnnotations.Schema;

namespace controleFinanceiro.Dtos.Responses
{
    public class UsuarioResponseDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email {  get; set; } = string.Empty;
        public string Cpf {  get; set; } = string.Empty;
        public string? Telefone {  get; set; }

        public ICollection<ContaResponseDto> Contas { get; set; } = [];
    }
}
