using System.ComponentModel.DataAnnotations;

namespace CSI_BE.Models
{
    public class LoginUserViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em um formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {1} e {2} caracteres", MinimumLength = 6)]
        public string Senha { get; set; }
    }
}
