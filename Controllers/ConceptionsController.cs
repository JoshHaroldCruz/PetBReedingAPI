using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetBreedingSystemAPI.Models;

namespace PetBreedingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConceptionsController : ControllerBase
    {
        private readonly BreedingSystemContext _context;

        public ConceptionsController(BreedingSystemContext context)
        {
            _context = context;
        }

        // GET: api/Conceptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Conception>>> GetConceptions()
        {
            return await _context.Conceptions.ToListAsync();
        }

        // GET: api/Conceptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Conception>> GetConception(int id)
        {
            var conception = await _context.Conceptions.FindAsync(id);

            if (conception == null)
            {
                return NotFound();
            }

            return conception;
        }

        // PUT: api/Conceptions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConception(int id, Conception conception)
        {
            if (id != conception.ConceptionId)
            {
                return BadRequest();
            }

            _context.Entry(conception).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConceptionExists(id))
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

        // POST: api/Conceptions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Conception>> PostConception(Conception conception)
        {
            _context.Conceptions.Add(conception);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConception", new { id = conception.ConceptionId }, conception);
        }

        // DELETE: api/Conceptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConception(int id)
        {
            var conception = await _context.Conceptions.FindAsync(id);
            if (conception == null)
            {
                return NotFound();
            }

            _context.Conceptions.Remove(conception);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConceptionExists(int id)
        {
            return _context.Conceptions.Any(e => e.ConceptionId == id);
        }
    }
}
