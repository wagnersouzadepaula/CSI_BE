using System.ComponentModel.DataAnnotations;

namespace CSI_BE.Models
{
    public class PessoaJuridica : Pessoa
    {
        [Required]
        public DateTime PrazoInicialDeDuracao { get; set; }

        [Required]
        public Socio Socio1 { get; set; }

        [Required]
        public Socio Socio2 { get; set; }

        [Required]
        public int QuotaSocio1 { get; set; }

        [Required]
        public int QuotaSocio2 { get; set; }

    }
}
