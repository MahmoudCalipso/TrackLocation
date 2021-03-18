using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackLocation.Hubs;
using TrackLocation.IRepository;
using TrackLocation.Model;

namespace TrackLocation.Repository
{
    public class LocationsRepository : ILocationsRepository
    {
        private readonly TrackLocationContext _context;
        

        public LocationsRepository(TrackLocationContext context)
        {
            _context = context;

        }
        public async Task<ActionResult<IEnumerable<Location>>> GetListLocation()
        {
            return await _context.Location.ToListAsync();
        }

        public async Task<ActionResult<Tracks>> SaveTracking( Tracks tracks)
        {  
            await _context.Tracks.AddAsync(tracks);
            await _context.SaveChangesAsync();
            return tracks;

        }

        /*
         *  Show All Tracking For SuperUser 
         */
        public async Task<ActionResult<IEnumerable<Location>>> GetAllTrackings()
        {
            var trackings = await _context.Location.Include(t => t.Tracks)
                .Include(d=> d.Car)
                .Include(u=> u.User)
                .ToListAsync();

            
            return trackings;
        }


        /*
         *  Show All Tracking For User Manager
         *  userManagerId => get it from the session to User Manager
         */
        public async Task<ActionResult<IEnumerable<Location>>> 
            GetAllDriversTrackingsForUserManager(long userManagerId)
        {
            var trackings = await _context.Location.Include(t => t.Tracks)
                .Include(d => d.Car)
                .Include(u => u.User)
                .Where(u=> u.User.CreatedByAdminID == userManagerId).ToListAsync();


            return trackings;
        }

        /*
         * 
         */
        public async Task<ActionResult<IEnumerable<Location>>> GetTrackingForDriver(long userid)
        {

            var trackings = await _context.Location.Include(t => t.Tracks)
               .Include(d => d.Car)
               .Include(u => u.User)
               .Where(u => u.User.UserId == userid).ToListAsync();


            return trackings;

        }


        /*
         *  Show Tracking Driver (Conducteur) For User Manager
         *     userManagerId => get it from the session to User Manager
         *     driverid => the liste of trackings for one driver
         */
        public async Task<ActionResult<IEnumerable<Location>>>
            GetAllTrackingsDriverForUserManager(long userManagerId, long driverid)
        {
            var trackings = await _context.Location.Include(t => t.Tracks)
                .Include(d => d.Car)
                .Include(u => u.User)
                .Where(u => u.User.CreatedByAdminID == userManagerId && u.UserId == driverid).ToListAsync();


            return trackings;
        }


        /*
        *  Show Tracking Driver (Conducteur) For User Manager
        *     userManagerId => get it from the session to User Manager
        *     Carid => the liste of trackings for Car 
        */
        public async Task<ActionResult<IEnumerable<Location>>>
            GetAllTrackingsCarForUserManager(long userManagerId, long carId)
        {
            var trackings = await _context.Location.Include(t => t.Tracks)
                .Include(d => d.Car)
                .Include(u => u.User)
                .Where(u => u.User.CreatedByAdminID == userManagerId && u.CarId == carId).ToListAsync();


            return trackings;
        }

        /*
         *  Show All Tracking For User (Conducteur)
         *  userid => will get this value from the session when the driver is connected 
         */
        public async Task<ActionResult<IEnumerable<Location>>> GetAllTrackingsForDriver(long userid)
        {
            var trackings = await _context.Location.Include(t => t.Tracks)
               .Include(d => d.Car)
               .Include(u => u.User)
               .Where( u => u.UserId == userid).ToListAsync();


            return trackings;
        }


        public async Task<ActionResult<Location>> GetLocation(long id)
        {
            var location = await _context.Location.FindAsync(id);

            if (location == null)
            {
                return null;
            }

            return location;
        }


        public async Task<ActionResult<Location>> PostLocation(Location location)
        {
            _context.Location.Add(location);     
            await _context.SaveChangesAsync();   
            return location;

        }

        public async Task<ActionResult<Location>> DeleteLocation(long id)
        {
            var location = await _context.Location.FindAsync(id);
            if (location == null)
            {
                return null;
            }
            _context.Location.Remove(location); 
            await _context.SaveChangesAsync();
            return location;
        }
        public bool LocationExists(long id)
        {
            return _context.Location.Any(e => e.LocationId == id);
        }

       
    }
}
