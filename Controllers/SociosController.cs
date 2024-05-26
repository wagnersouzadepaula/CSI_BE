using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CSI_BE.Data;
using CSI_BE.Models;
using System.Globalization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace CSI_BE.Controllers
{
    [Authorize]
    [ApiController]
    public class SociosController : ControllerBase
    {
        private readonly CsiBeDbContext _context;

        public SociosController(CsiBeDbContext context)
        {
            _context = context;
        }

        // GET: api/Socios/todosSocios/7de3028b-50f4-4fe4-82ef-573d31bedee3
        [HttpGet]
        [Route("api/socios/todosSocios/{userId}")]
        public async Task<ActionResult<IEnumerable<Socio>>> GetSocio(string userId)
        {
            return await _context.Socio.Where(e => e.UserId == userId).ToListAsync();
        }

        // GET: api/Socios/7de3028b-50f4-4fe4-82ef-573d31bedee3/5
        [HttpGet("api/socios/{userId}/{id}")]
        public async Task<ActionResult<Socio>> GetSocio(string userId,int id)
        {
            var socio = await _context.Socio.Where(e => e.UserId == userId && e.Id == id).FirstOrDefaultAsync();

            if (socio == null)
            {
                return NotFound();
            }

            return socio;
        }

        // GET: api/Socios/5
        [HttpGet("api/socios/{id}")]
        public async Task<ActionResult<Socio>> GetSocio(int id)
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
        [HttpPut("api/socios/{id}")]
        public async Task<IActionResult> PutSocio(int id, Socio socio)
        {
            if (id != socio.Id)
            {
                return BadRequest();
            }

            socio = FormatarTexto(socio);
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
        [HttpPost("api/socios/")]
        public async Task<ActionResult<Socio>> PostSocio(Socio socio)
        {
            //socio = FormatarTexto(socio);
            _context.Socio.Add(socio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSocio", new { id = socio.Id }, socio);
        }

        // DELETE: api/Socios/5
        [HttpDelete("api/socios/{id}")]
        public async Task<IActionResult> DeleteSocio(int id)
        {
            var socio = await _context.Socio.FindAsync(id);
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

        private Socio FormatarTexto(Socio socio)
        {
            TextInfo myTI = new CultureInfo("pt-BR", false).TextInfo;
            socio.Nome = myTI.ToTitleCase(socio.Nome);
            socio.Endereco = myTI.ToTitleCase(socio.Endereco);
            socio.NroImovel = myTI.ToTitleCase(socio.NroImovel);
            socio.Complemento = myTI.ToTitleCase(socio.Complemento);
            socio.Bairro = myTI.ToTitleCase(socio.Bairro);
            socio.Cidade = myTI.ToTitleCase(socio.Cidade);
            socio.Uf = socio.Uf.ToUpper();
            socio.Cep = myTI.ToTitleCase(socio.Cep);
            socio.Nacionalidade = myTI.ToTitleCase(socio.Nacionalidade);
            socio.Profissao = myTI.ToTitleCase(socio.Profissao);
            socio.Rg = myTI.ToTitleCase(socio.Rg);
            socio.Cpf = myTI.ToTitleCase(socio.Cpf);

            return socio;
        }
    }
}
