using CSI_BE.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CSI_BE.Models
{
    public class Socio : Pessoa
    {

        [Required]
        public string Nacionalidade { get; set; } = "brasileiro";

        [Required]
        public EstCivil EstadoCivil { get; set; }

        public string MaioridadeCivil { get; set; } = "maior de idade";

        [Required]
        public string Profissao { get; set; }

        [Required]
        public string Rg { get; set; }

        [Required]
        public string Cpf { get; set; }

    }
}
