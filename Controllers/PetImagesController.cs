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
    public class PetImagesController : ControllerBase
    {
        private readonly BreedingSystemContext _context;

        public PetImagesController(BreedingSystemContext context)
        {
            _context = context;
        }

        // GET: api/PetImages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetImage>>> GetPetImages()
        {
            return await _context.PetImages.ToListAsync();
        }

        // GET: api/PetImages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PetImage>> GetPetImage(int id)
        {
            var petImage = await _context.PetImages.FindAsync(id);

            if (petImage == null)
            {
                return NotFound();
            }

            return petImage;
        }

        // PUT: api/PetImages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPetImage(int id, PetImage petImage)
        {
            if (id != petImage.PetImageId)
            {
                return BadRequest();
            }

            _context.Entry(petImage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetImageExists(id))
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

        // POST: api/PetImages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PetImage>> PostPetImage(PetImage petImage)
        {
            _context.PetImages.Add(petImage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPetImage", new { id = petImage.PetImageId }, petImage);
        }

        // DELETE: api/PetImages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePetImage(int id)
        {
            var petImage = await _context.PetImages.FindAsync(id);
            if (petImage == null)
            {
                return NotFound();
            }

            _context.PetImages.Remove(petImage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PetImageExists(int id)
        {
            return _context.PetImages.Any(e => e.PetImageId == id);
        }
    }
}
