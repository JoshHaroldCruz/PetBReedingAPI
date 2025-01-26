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
    public class HealthRecordsController : ControllerBase
    {
        private readonly BreedingSystemContext _context;

        public HealthRecordsController(BreedingSystemContext context)
        {
            _context = context;
        }

        // GET: api/HealthRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HealthRecord>>> GetHealthRecords()
        {
            return await _context.HealthRecords.ToListAsync();
        }

        // GET: api/HealthRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HealthRecord>> GetHealthRecord(int id)
        {
            var healthRecord = await _context.HealthRecords.FindAsync(id);

            if (healthRecord == null)
            {
                return NotFound();
            }

            return healthRecord;
        }

        // PUT: api/HealthRecords/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHealthRecord(int id, HealthRecord healthRecord)
        {
            if (id != healthRecord.RecordId)
            {
                return BadRequest();
            }

            _context.Entry(healthRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HealthRecordExists(id))
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

        // POST: api/HealthRecords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HealthRecord>> PostHealthRecord(HealthRecord healthRecord)
        {
            _context.HealthRecords.Add(healthRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHealthRecord", new { id = healthRecord.RecordId }, healthRecord);
        }

        // DELETE: api/HealthRecords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHealthRecord(int id)
        {
            var healthRecord = await _context.HealthRecords.FindAsync(id);
            if (healthRecord == null)
            {
                return NotFound();
            }

            _context.HealthRecords.Remove(healthRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HealthRecordExists(int id)
        {
            return _context.HealthRecords.Any(e => e.RecordId == id);
        }
    }
}
