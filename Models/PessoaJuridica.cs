using System.ComponentModel.DataAnnotations;

namespace CSI_BE.Models
{
    public class PessoaJuridica : Pessoa
    {
        [Required]
        public DateOnly PrazoInicialDeDuracao { get; set; }

        [Required]
        public int Socio1Id { get; set; }
        public Socio Socio1 { get; set; }

        [Required]
        public int Socio2Id { get; set; }
        public Socio Socio2 { get; set; }

        [Required]
        public int QuotaSocio1 { get; set; }

        [Required]
        public int QuotaSocio2 { get; set; }

        [Required]
        public int CnaeId { get; set; }
        public Cnae Cnae { get; set; }

    }
}
