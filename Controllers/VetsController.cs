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
    public class VetsController : ControllerBase
    {
        private readonly BreedingSystemContext _context;

        public VetsController(BreedingSystemContext context)
        {
            _context = context;
        }

        // GET: api/Vets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vet>>> GetVets()
        {
            return await _context.Vets.ToListAsync();
        }

        // GET: api/Vets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vet>> GetVet(int id)
        {
            var vet = await _context.Vets.FindAsync(id);

            if (vet == null)
            {
                return NotFound();
            }

            return vet;
        }

        // PUT: api/Vets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVet(int id, Vet vet)
        {
            if (id != vet.VetId)
            {
                return BadRequest();
            }

            _context.Entry(vet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VetExists(id))
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

        // POST: api/Vets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vet>> PostVet(Vet vet)
        {
            _context.Vets.Add(vet);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VetExists(vet.VetId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVet", new { id = vet.VetId }, vet);
        }

        // DELETE: api/Vets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVet(int id)
        {
            var vet = await _context.Vets.FindAsync(id);
            if (vet == null)
            {
                return NotFound();
            }

            _context.Vets.Remove(vet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VetExists(int id)
        {
            return _context.Vets.Any(e => e.VetId == id);
        }
    }
}
