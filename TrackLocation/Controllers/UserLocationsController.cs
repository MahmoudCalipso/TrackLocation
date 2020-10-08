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
    public class UserLocationsController : ControllerBase
    {
        private readonly TrackLocationContext _context;

        public UserLocationsController(TrackLocationContext context)
        {
            _context = context;
        }

        // GET api/<UserLocationsController>/5
        [HttpGet("{id}")]
        public ActionResult<Location> GetUserLocations(int userid)
        {
            IQueryable<Location> result = from location in _context.Location
                                          join user in _context.User
                                          on location.User.UserId equals user.UserId
                                          where location.UserId == userid

                                          select new Location
                                          {
                                              LocationId = location.LocationId,
                                              StartDate = location.StartDate,
                                              EndDate = location.EndDate,
                                              Tracking = location.Tracking,
                                              UserId = location.UserId

                                          };

            IQueryable<Location> ListLocation = result;
            return (Location)ListLocation;
        }

        [HttpGet("{userId}/locationId")]
        public ActionResult<Location> GetUserLocation(int userid, int locationId)
        {
            IQueryable<Location> result = from location in _context.Location
                                          join user in _context.User
                                          on location.User.UserId equals user.UserId
                                          where location.UserId == userid && location.LocationId == locationId

                                          select new Location
                                          {
                                              LocationId = location.LocationId,
                                              StartDate = location.StartDate,
                                              EndDate = location.EndDate,
                                              Tracking = location.Tracking,
                                              UserId = location.UserId

                                          };

            IQueryable<Location> ListLocation = result;
            return (Location)ListLocation;
        }

        [HttpDelete("{userid}/{locId}")]
        public async Task<ActionResult<Location>> DeleteUserLocation(long userid, long locId)
        {
            var location = await _context.Location.Include(u => u.LocationId == locId).FirstOrDefaultAsync(car => car.UserId == userid);
            if (location == null)
            {
                return NotFound();
            }

            _context.Location.Remove(location);
            await _context.SaveChangesAsync();

            return Ok();
        }


    }
}
