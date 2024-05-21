using System.ComponentModel.DataAnnotations;

namespace CSI_BE.Models
{
    public class ObjetoSocial
    {
        [Key]
        public int Id { get; set; }

        public int CnaeId { get; set; }
        public Cnae Cnae { get; set; }

        public int PessoaJudicaId { get; set; }
        public PessoaJuridica PessoaJuridica { get; set; }
    }

}
