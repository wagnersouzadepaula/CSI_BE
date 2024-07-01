using CSI_BE.Models;

namespace CSI_BE.DTO
{
    public class ContratoSocialDTO
    {
        public PessoaJuridica Pj { get; set; }
        public Socio Socio1 { get; set; }
        public Socio Socio2 { get; set; }
        public string CodVerificador { get; set; }
        public string Cnae { get; set; }


        public ContratoSocialDTO(PessoaJuridica pj, Socio socio1, Socio socio2 )
        {
            Pj = pj;
            Socio1 = socio1;
            Socio2 = socio2;
        }

    }

    
}
