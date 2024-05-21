using System.ComponentModel.DataAnnotations;

namespace CSI_BE.Models
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }

        [Required]
        public string Endereco { get; set; }

        [Required]
        public string NroImovel { get; set; }

        public string? Complemento { get; set; }

        [Required]
        public string Bairro { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Uf { get; set; }

        [Required]
        public string Cep { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public LoginUserViewModel Email { get; set; }
    }
}
