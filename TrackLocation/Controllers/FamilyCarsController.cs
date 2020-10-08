using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackLocation.Model;

namespace TrackLocation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyCarsController : ControllerBase
    {
        private readonly TrackLocationContext _context;

        public FamilyCarsController(TrackLocationContext context)
        {
            _context = context;
        }

        // GET: api/FamilyCars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FamilyCar>>> GetFamilyCar()
        {
            return await _context.FamilyCar.ToListAsync();
        }

        // GET: api/FamilyCars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FamilyCar>> GetFamilyCar(long id)
        {
            var familyCar = await _context.FamilyCar.FindAsync(id);

            if (familyCar == null)
            {
                return NotFound();
            }

            return familyCar;
        }

        // PUT: api/FamilyCars/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFamilyCar(long id, FamilyCar familyCar)
        {
            if (id != familyCar.FamilyCarId)
            {
                return BadRequest();
            }

            _context.Entry(familyCar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FamilyCarExists(id))
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

        // POST: api/FamilyCars
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FamilyCar>> PostFamilyCar(FamilyCar familyCar)
        {
            _context.FamilyCar.Add(familyCar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFamilyCar", new { id = familyCar.FamilyCarId }, familyCar);
        }

        // DELETE: api/FamilyCars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FamilyCar>> DeleteFamilyCar(long id)
        {
            var familyCar = await _context.FamilyCar.FindAsync(id);
            if (familyCar == null)
            {
                return NotFound();
            }

            _context.FamilyCar.Remove(familyCar);
            await _context.SaveChangesAsync();

            return familyCar;
        }

        private bool FamilyCarExists(long id)
        {
            return _context.FamilyCar.Any(e => e.FamilyCarId == id);
        }
    }
}
