
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using servicos_api.Models;

namespace servicos_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefoneController : ControllerBase
    {
        private readonly servicosContext _context;

        public TelefoneController(servicosContext context)
        {
            _context = context;
        }

        // GET: api/Telefone
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Telefone>>> GetTelefones()
        {
            return await _context.Telefones.ToListAsync();
        }

        // GET: api/Telefone/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Telefone>> GetTelefone(int id)
        {
            var telefone = await _context.Telefones.FindAsync(id);

            if (telefone == null)
            {
                return NotFound();
            }

            return telefone;
        }

        // PUT: api/Telefone/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTelefone(int id, Telefone telefone)
        {
            if (id != telefone.Id)
            {
                return BadRequest();
            }

            _context.Entry(telefone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelefoneExists(id))
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

        // POST: api/Telefone
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Telefone>> PostTelefone(Telefone telefone)
        {
            _context.Telefones.Add(telefone);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTelefone", new { id = telefone.Id }, telefone);
        }

        // DELETE: api/Telefone/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTelefone(int id)
        {
            var telefone = await _context.Telefones.FindAsync(id);
            if (telefone == null)
            {
                return NotFound();
            }

            _context.Telefones.Remove(telefone);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TelefoneExists(int id)
        {
            return _context.Telefones.Any(e => e.Id == id);
        }
    }
}
