using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace CSI_BE.Models
{
    public class ContratoSocial
    {
        [Key]
        public int Id { get; set; }

        public string CodVerificador { get; set; }

        public byte[]? Pdf { get; set; }

        [Required]
        public int PessoaJuridicaId { get; set; }
    }
}
