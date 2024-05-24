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

namespace CSI_BE.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CnaesController : ControllerBase
    {
        private readonly CsiBeDbContext _context;

        public CnaesController(CsiBeDbContext context)
        {
            _context = context;
        }

        // GET: api/Cnaes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cnae>>> GetCnae()
        {
            return await _context.Cnae.ToListAsync();
        }

        // GET: api/Cnaes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cnae>> GetCnae(int id)
        {
            var cnae = await _context.Cnae.FindAsync(id);

            if (cnae == null)
            {
                return NotFound();
            }

            return cnae;
        }

        // PUT: api/Cnaes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCnae(int id, Cnae cnae)
        {
            if (id != cnae.Id)
            {
                return BadRequest();
            }

            _context.Entry(cnae).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CnaeExists(id))
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

        // POST: api/Cnaes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cnae>> PostCnae(Cnae cnae)
        {
            _context.Cnae.Add(cnae);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCnae", new { id = cnae.Id }, cnae);
        }

        // DELETE: api/Cnaes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCnae(int id)
        {
            var cnae = await _context.Cnae.FindAsync(id);
            if (cnae == null)
            {
                return NotFound();
            }

            _context.Cnae.Remove(cnae);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CnaeExists(int id)
        {
            return _context.Cnae.Any(e => e.Id == id);
        }
    }
}
