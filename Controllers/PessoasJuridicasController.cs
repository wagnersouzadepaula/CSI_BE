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
using System.Globalization;

namespace CSI_BE.Controllers
{
    [Authorize]
    [ApiController]
    public class PessoasJuridicasController : ControllerBase
    {
        private readonly CsiBeDbContext _context;

        public PessoasJuridicasController(CsiBeDbContext context)
        {
            _context = context;
        }

        // GET: api/PessoaJuridicas/todaspjs/7de3028b-50f4-4fe4-82ef-573d31bedee3
        [HttpGet]
        [Route("api/pessoasjuridicas/todaspjs/{userId}")]
        public async Task<ActionResult<IEnumerable<PessoaJuridica>>> GetPessoaJuridica(string userId)
        {
            return await _context.PessoaJuridica.Where(e => e.UserId == userId).ToListAsync();
        }

        // GET: api/PessoaJuridicas/7de3028b-50f4-4fe4-82ef-573d31bedee3/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PessoaJuridica>> GetPessoaJuridica(string userId,int id)
        {
            var pessoaJuridica = await _context.PessoaJuridica.Where(e=> e.UserId == userId && e.Id == id).FirstOrDefaultAsync();

            if (pessoaJuridica == null)
            {
                return NotFound();
            }

            return pessoaJuridica;
        }

        // GET: api/PessoaJuridicas/todaspjs/7de3028b-50f4-4fe4-82ef-573d31bedee3
        [HttpGet]
        [Route("api/pessoasjuridicas/{id}")]
        public async Task<ActionResult<PessoaJuridica>> GetPessoaJuridica(int id)
        { 
            var pessoaJuridica = await _context.PessoaJuridica.FindAsync(id);

            if (pessoaJuridica == null) { return NotFound(); }

            return pessoaJuridica;
        }
        // PUT: api/PessoaJuridicas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("api/pessoasjuridicas/{id}")]

        public async Task<IActionResult> PutPessoaJuridica(int id, PessoaJuridica pessoaJuridica)
        {
            if (id != pessoaJuridica.Id)
            {
                return BadRequest();
            }

            pessoaJuridica = FormatarTexto(pessoaJuridica);
            _context.Entry(pessoaJuridica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PessoaJuridicaExists(id))
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

        // POST: api/PessoaJuridicas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("api/pessoasjuridicas/")]
        public async Task<ActionResult<PessoaJuridica>> PostPessoaJuridica(PessoaJuridica pessoaJuridica)
        {
            pessoaJuridica = FormatarTexto(pessoaJuridica);
            _context.PessoaJuridica.Add(pessoaJuridica);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPessoaJuridica", new { id = pessoaJuridica.Id }, pessoaJuridica);
        }

        // DELETE: api/PessoaJuridicas/5
        [HttpDelete]
        [Route("api/pessoasjuridicas/{id}")]
        public async Task<IActionResult> DeletePessoaJuridica(int id)
        {
            var pessoaJuridica = await _context.PessoaJuridica.FindAsync(id);
            if (pessoaJuridica == null)
            {
                return NotFound();
            }

            _context.PessoaJuridica.Remove(pessoaJuridica);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PessoaJuridicaExists(int id)
        {
            return _context.PessoaJuridica.Any(e => e.Id == id);
        }

        private PessoaJuridica FormatarTexto(PessoaJuridica pessoaJuridica)
        {
            TextInfo myTI = new CultureInfo("pt-BR", false).TextInfo;
            pessoaJuridica.Nome = myTI.ToTitleCase(pessoaJuridica.Nome);
            pessoaJuridica.Endereco = myTI.ToTitleCase(pessoaJuridica.Endereco);
            pessoaJuridica.NroImovel = myTI.ToTitleCase(pessoaJuridica.NroImovel);
            pessoaJuridica.Complemento = myTI.ToTitleCase(pessoaJuridica.Complemento);
            pessoaJuridica.Bairro = myTI.ToTitleCase(pessoaJuridica.Bairro);
            pessoaJuridica.Cidade = myTI.ToTitleCase(pessoaJuridica.Cidade);
            pessoaJuridica.Uf = pessoaJuridica.Uf.ToUpper();
            pessoaJuridica.Cep = myTI.ToTitleCase(pessoaJuridica.Cep);
            return pessoaJuridica;
        }
    }
}
