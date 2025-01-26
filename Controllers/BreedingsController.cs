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
    public class BreedingsController : ControllerBase
    {
        private readonly BreedingSystemContext _context;

        public BreedingsController(BreedingSystemContext context)
        {
            _context = context;
        }

        // GET: api/Breedings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Breeding>>> GetBreedings()
        {
            return await _context.Breedings.ToListAsync();
        }

        // GET: api/Breedings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Breeding>> GetBreeding(int id)
        {
            var breeding = await _context.Breedings.FindAsync(id);

            if (breeding == null)
            {
                return NotFound();
            }

            return breeding;
        }

        // PUT: api/Breedings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBreeding(int id, Breeding breeding)
        {
            if (id != breeding.BreedingId)
            {
                return BadRequest();
            }

            _context.Entry(breeding).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BreedingExists(id))
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

        // POST: api/Breedings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Breeding>> PostBreeding(Breeding breeding)
        {
            _context.Breedings.Add(breeding);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBreeding", new { id = breeding.BreedingId }, breeding);
        }

        // DELETE: api/Breedings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBreeding(int id)
        {
            var breeding = await _context.Breedings.FindAsync(id);
            if (breeding == null)
            {
                return NotFound();
            }

            _context.Breedings.Remove(breeding);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BreedingExists(int id)
        {
            return _context.Breedings.Any(e => e.BreedingId == id);
        }
    }
}
