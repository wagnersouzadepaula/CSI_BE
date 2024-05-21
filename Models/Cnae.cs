using System.ComponentModel.DataAnnotations;

namespace CSI_BE.Models
{
    public class Cnae
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CodCnae { get; set; }

        [Required]
        public string DescCnae { get; set;}
    }
}
