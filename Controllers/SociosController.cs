using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CSI_BE.Data;
using CSI_BE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CSI_BE.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SociosController : ControllerBase
    {
        private readonly CsiBeDbContext _context;

        public SociosController(CsiBeDbContext context)
        {
            _context = context;
        }

        // GET: api/Socios
        [HttpGet]
        [Route("{userId}")]

        public async Task<ActionResult<IEnumerable<Socio>>> GetSocio(string userId)
        {
            return await _context.Socio.Where(e => e.UserId == userId).ToListAsync();
        }

        // GET: api/Socios/5
        [HttpGet("{userId}/{id}")]
        public async Task<ActionResult<Socio>> GetSocio(string userId, int id)
        {
            var socio = await _context.Socio.FindAsync(id);

            if (socio == null)
            {
                return NotFound();
            }

            return socio;
        }

        // PUT: api/Socios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSocio(int id, Socio socio)
        {

            if (id != socio.Id)
            {
                return BadRequest();
            }

            socio = ToUpperCase(socio);
            _context.Entry(socio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SocioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Socios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("")]
        public async Task<ActionResult<Socio>> PostSocio(Socio socio)
        {
            socio = ToUpperCase(socio);
            _context.Socio.Add(socio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSocio", new { id = socio.Id }, socio);
        }

        // DELETE: api/Socios/5
        [HttpDelete("{userId}/{id}")]
        public async Task<IActionResult> DeleteSocio(string userId,int id )
        {
            var socio = await _context.Socio.Where(e => e.UserId == userId && e.Id == id).FirstAsync();
            if (socio == null)
            {
                return NotFound();
            }

            _context.Socio.Remove(socio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SocioExists(int id)
        {
            return _context.Socio.Any(e => e.Id == id);
        }

        private Socio ToUpperCase(Socio socio)
        {
            socio.Nome = socio.Nome.ToUpper();
            socio.Endereco =  socio.Endereco.ToUpper();
            socio.NroImovel = socio.NroImovel.ToUpper();
            socio.Complemento = socio.Complemento.ToUpper();
            socio.Bairro = socio.Bairro.ToUpper();
            socio.Cidade = socio.Cidade.ToUpper();
            socio.Uf = socio.Uf.ToUpper();
            socio.Cep = socio.Cep.ToUpper();
            socio.Nacionalidade = socio.Nacionalidade.ToUpper();
            socio.Profissao = socio.Profissao.ToUpper();
            socio.Rg = socio.Rg.ToUpper();
            socio.Cpf = socio.Cpf.ToUpper();

            return socio;
        }
    }
}
