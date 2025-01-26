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
    public class PetFilesController : ControllerBase
    {
        private readonly BreedingSystemContext _context;

        public PetFilesController(BreedingSystemContext context)
        {
            _context = context;
        }

        // GET: api/PetFiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetFile>>> GetPetFiles()
        {
            return await _context.PetFiles.ToListAsync();
        }

        // GET: api/PetFiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PetFile>> GetPetFile(int id)
        {
            var petFile = await _context.PetFiles.FindAsync(id);

            if (petFile == null)
            {
                return NotFound();
            }

            return petFile;
        }

        // PUT: api/PetFiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPetFile(int id, PetFile petFile)
        {
            if (id != petFile.FileId)
            {
                return BadRequest();
            }

            _context.Entry(petFile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetFileExists(id))
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

        // POST: api/PetFiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PetFile>> PostPetFile(PetFile petFile)
        {
            _context.PetFiles.Add(petFile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPetFile", new { id = petFile.FileId }, petFile);
        }

        // DELETE: api/PetFiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePetFile(int id)
        {
            var petFile = await _context.PetFiles.FindAsync(id);
            if (petFile == null)
            {
                return NotFound();
            }

            _context.PetFiles.Remove(petFile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PetFileExists(int id)
        {
            return _context.PetFiles.Any(e => e.FileId == id);
        }
    }
}
