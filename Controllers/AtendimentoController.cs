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
    public class AtendimentoController : ControllerBase
    {
        private readonly servicosContext _context;

        public AtendimentoController(servicosContext context)
        {
            _context = context;
        }

        // GET: api/Atendimento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Atendimento>>> GetAtendimentos()
        {
            return await _context.Atendimentos.ToListAsync();
        }

        // GET: api/Atendimento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Atendimento>> GetAtendimento(int id)
        {
            var atendimento = await _context.Atendimentos.FindAsync(id);

            if (atendimento == null)
            {
                return NotFound();
            }

            return atendimento;
        }

        // PUT: api/Atendimento/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAtendimento(int id, Atendimento atendimento)
        {
            if (id != atendimento.Id)
            {
                return BadRequest();
            }

            _context.Entry(atendimento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtendimentoExists(id))
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

        // POST: api/Atendimento
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Atendimento>> PostAtendimento(Atendimento atendimento)
        {
            _context.Atendimentos.Add(atendimento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAtendimento", new { id = atendimento.Id }, atendimento);
        }

        // DELETE: api/Atendimento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAtendimento(int id)
        {
            var atendimento = await _context.Atendimentos.FindAsync(id);
            if (atendimento == null)
            {
                return NotFound();
            }

            _context.Atendimentos.Remove(atendimento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AtendimentoExists(int id)
        {
            return _context.Atendimentos.Any(e => e.Id == id);
        }
    }
}
