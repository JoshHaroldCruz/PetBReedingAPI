﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetBreedingSystemAPI.Models;
using PetBreedingSystemAPI.Models.DTOs;

namespace PetBreedingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreedsController : ControllerBase
    {
        private readonly BreedingSystemContext _context;

        public BreedsController(BreedingSystemContext context)
        {
            _context = context;
        }

        // GET: api/Breeds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Breed>>> GetBreeds()
        {
            return await _context.Breeds.ToListAsync();
        }

        // GET: api/Breeds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Breed>> GetBreed(int id)
        {
            var breed = await _context.Breeds.FindAsync(id);

            if (breed == null)
            {
                return NotFound();
            }

            return breed;
        }

        // PUT: api/Breeds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBreed(int id, Breed breed)
        {
            if (id != breed.BreedId)
            {
                return BadRequest();
            }

            _context.Entry(breed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BreedExists(id))
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

        // POST: api/Breeds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Breed>> PostBreed(Breed breed)
        {
            _context.Breeds.Add(breed);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBreed", new { id = breed.BreedId }, breed);
        }

        // DELETE: api/Breeds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBreed(int id)
        {
            var breed = await _context.Breeds.FindAsync(id);
            if (breed == null)
            {
                return NotFound();
            }

            _context.Breeds.Remove(breed);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BreedExists(int id)
        {
            return _context.Breeds.Any(e => e.BreedId == id);
        }

        [HttpGet("bySpecies/{speciesId}")]
        public async Task<ActionResult<IEnumerable<BreedDto>>> GetBreedsBySpecies(int speciesId)
        {
            var breeds = await _context.Breeds
                .Where(b => b.SpeciesId == speciesId)
                .Select(b => new BreedDto
                {
                    BreedId = b.BreedId,
                    BreedName = b.BreedName
                })
                .ToListAsync();

            return Ok(breeds);
        }
    }
}
