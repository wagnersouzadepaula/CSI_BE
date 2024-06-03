using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CSI_BE.Models;

namespace CSI_BE.Data
{
    public class CsiBeDbContext : IdentityDbContext
    {
        public CsiBeDbContext(DbContextOptions<CsiBeDbContext> options) : base(options) {  }
        public DbSet<IdentityUser> AspNetUsers {  get; set; }
        public DbSet<CSI_BE.Models.Cnae> Cnae { get; set; } = default!;
        public DbSet<CSI_BE.Models.Socio> Socio { get; set; } = default!;
        public DbSet<CSI_BE.Models.PessoaJuridica> PessoaJuridica { get; set; } = default!;
        
    }
}
