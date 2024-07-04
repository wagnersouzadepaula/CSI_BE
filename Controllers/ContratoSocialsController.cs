using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CSI_BE.Data;
using CSI_BE.Models;
using CSI_BE.DTO;
using CSI_BE.Services;
using System.Drawing.Text;
using Microsoft.AspNetCore.Authorization;

namespace CSI_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoSocialsController : ControllerBase
    {
        private readonly CsiBeDbContext _context;

        public ContratoSocialsController(CsiBeDbContext context)
        {
            _context = context;
        }

        // GET: api/ContratoSocials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContratoSocial>>> GetContratoSocial()
        {
            return await _context.ContratoSocial.ToListAsync();
        }

        // GET: api/ContratoSocials/5
        [HttpGet("{hash}")]
        public async Task<ActionResult<ContratoSocial>> GetContratoSocial(string hash)
        {
            var contratoSocial = await _context.ContratoSocial.FirstAsync(t => t.CodVerificador == hash);

            PessoaJuridica pessoaJuridica = await _context.PessoaJuridica.FindAsync(contratoSocial.PessoaJuridicaId);
            Socio socio1 = await _context.Socio.FindAsync(pessoaJuridica.Socio1Id);
            Socio socio2 = await _context.Socio.FindAsync(pessoaJuridica.Socio2Id);
            Cnae cnae = await _context.Cnae.FindAsync(pessoaJuridica.CnaeId);
            ContratoSocialDTO contratoSocialDTO = new ContratoSocialDTO(pessoaJuridica, socio1, socio2);
            contratoSocialDTO.CodVerificador = contratoSocial.CodVerificador;
            contratoSocialDTO.Cnae = $"{cnae.CodCnae} - {cnae.DescCnae}";
            contratoSocial.Pdf = MontaPdf.MontarPdf(contratoSocialDTO);

            if (contratoSocial == null)
            {
                return NotFound();
            }

            return contratoSocial;
        }

        // PUT: api/ContratoSocials/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutContratoSocial(int id, ContratoSocial contratoSocial)
        //{
        //    if (id != contratoSocial.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(contratoSocial).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ContratoSocialExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/ContratoSocials
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost("{id}")]
        public async Task<ActionResult<ContratoSocial>> PostContratoSocial(int id)
        {

            PessoaJuridica pessoaJuridica = await _context.PessoaJuridica.FindAsync(id);

            Socio socio1 = await _context.Socio.FindAsync(pessoaJuridica.Socio1Id);
            Socio socio2 = await _context.Socio.FindAsync(pessoaJuridica.Socio2Id);
            Cnae cnae = await _context.Cnae.FindAsync(pessoaJuridica.CnaeId);

            string CodVerificador = $"{Guid.NewGuid().ToString() + DateTime.Today.Year + DateTime.Today.Month + DateTime.Today.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second}";
            ContratoSocialDTO contratoSocialDTO = new ContratoSocialDTO(pessoaJuridica, socio1, socio2);
            contratoSocialDTO.CodVerificador = CodVerificador;
            contratoSocialDTO.Cnae = $"{cnae.CodCnae} - {cnae.DescCnae}";



            ContratoSocial contratoSocial = new ContratoSocial();

            
            contratoSocial.Pdf = MontaPdf.MontarPdf(contratoSocialDTO);
            contratoSocial.PessoaJuridicaId = id;
            contratoSocial.CodVerificador = CodVerificador;

            _context.ContratoSocial.Add(contratoSocial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContratoSocial", new { id = contratoSocial.Id }, contratoSocial);
        }

        // DELETE: api/ContratoSocials/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteContratoSocial(int id)
        //{
        //    var contratoSocial = await _context.ContratoSocial.FindAsync(id);
        //    if (contratoSocial == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.ContratoSocial.Remove(contratoSocial);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool ContratoSocialExists(int id)
        {
            return _context.ContratoSocial.Any(e => e.Id == id);
        }
    }
}
