using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackLocation.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrackLocation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCarsController : ControllerBase
    {

        private readonly TrackLocationContext _context;
        public UserCarsController(TrackLocationContext context)
        {
            _context = context;
        }

        // GET api/<UserCarsController>/5
        [HttpGet("userid")]
        public ActionResult<Car> GetUserCars(int userid)
        {
            var result = from car in _context.Car
                         join user in _context.User
                         on car.User.UserId equals user.UserId
                         where car.UserId == userid

                         select new Car
                         {
                             CarId = car.CarId,
                             NameCar = car.NameCar,
                             DateCirculation = car.DateCirculation,
                             Matricule = car.Matricule,
                             Puissance = car.Puissance,
                             NumberPlace = car.NumberPlace,
                             TotKm = car.TotKm,
                             FamilyCarId = car.FamilyCarId,
                             TypeCarId = car.TypeCarId,
                             UserId = car.UserId

                         };

            IQueryable<Car> ListCar = result;
            return (Car)ListCar;
        }

        [HttpGet("UserId/CarId")]
        public ActionResult<Car> GetUserCar(int UserId, int CarId)
        {
            var result = from car in _context.Car
                         join user in _context.User
                         on car.User.UserId equals user.UserId
                         where car.UserId == UserId && car.CarId == CarId


                         select new Car
                         {
                             CarId = car.CarId,
                             NameCar = car.NameCar,
                             DateCirculation = car.DateCirculation,
                             Matricule = car.Matricule,
                             Puissance = car.Puissance,
                             NumberPlace = car.NumberPlace,
                             TotKm = car.TotKm,
                             FamilyCarId = car.FamilyCarId,
                             TypeCarId = car.TypeCarId,
                             UserId = car.UserId

                         };

            IQueryable<Car> ListCar = result;
            return (Car)ListCar;
        }

        [HttpPut("{userId}/{carId}")]
        public async Task<IActionResult> UpdateUserCar (long userId, long carId )
        {
            var user =  _context.User.Find(userId);
            var car = _context.Car.Where(c => c.CarId == carId).Where(user => user.UserId == userId);
            if ( car == null  )
            {
                return BadRequest();
            }

            _context.Entry(car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(carId))
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


        [HttpDelete("{userid}/{carid}")]
        public async Task<ActionResult<Car>> DeleteUserCar(long userid, long carid)
        {
            var car = await _context.Car.Include(u => u.CarId == carid).FirstOrDefaultAsync(car =>car.UserId == userid);
            if (car == null)
            {
                return NotFound();
            }

            _context.Car.Remove(car);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool CarExists(long id)
        {
            return _context.Car.Any(e => e.CarId == id);
        }

    }
}
