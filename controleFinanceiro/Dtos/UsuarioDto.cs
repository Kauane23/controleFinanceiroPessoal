using System.ComponentModel.DataAnnotations;

namespace controleFinanceiro.Dtos
{
    public class UsuarioDto
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(200)]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
        [StringLength(200)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(50)]
        public string Cpf { get; set; } = string.Empty;

        [StringLength(50)]
        public string? Telefone { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        public string Senha { get; set; } = string.Empty;
    }
}
