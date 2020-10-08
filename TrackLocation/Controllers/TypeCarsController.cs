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
    public class TypeCarsController : ControllerBase
    {
        private readonly TrackLocationContext _context;

        public TypeCarsController(TrackLocationContext context)
        {
            _context = context;
        }

        // GET: api/TypeCars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeCar>>> GetTypeCar()
        {
            return await _context.TypeCar.ToListAsync();
        }

        // GET: api/TypeCars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeCar>> GetTypeCar(long id)
        {
            var typeCar = await _context.TypeCar.FindAsync(id);

            if (typeCar == null)
            {
                return NotFound();
            }

            return typeCar;
        }

        // PUT: api/TypeCars/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeCar(long id, TypeCar typeCar)
        {
            if (id != typeCar.TypeCarId)
            {
                return BadRequest();
            }

            _context.Entry(typeCar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeCarExists(id))
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

        // POST: api/TypeCars
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TypeCar>> PostTypeCar(TypeCar typeCar)
        {
            _context.TypeCar.Add(typeCar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeCar", new { id = typeCar.TypeCarId }, typeCar);
        }

        // DELETE: api/TypeCars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TypeCar>> DeleteTypeCar(long id)
        {
            var typeCar = await _context.TypeCar.FindAsync(id);
            if (typeCar == null)
            {
                return NotFound();
            }

            _context.TypeCar.Remove(typeCar);
            await _context.SaveChangesAsync();

            return typeCar;
        }

        private bool TypeCarExists(long id)
        {
            return _context.TypeCar.Any(e => e.TypeCarId == id);
        }
    }
}
