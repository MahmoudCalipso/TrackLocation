using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackLocation.Model;

namespace TrackLocation.IRepository
{
    public interface ILocationsRepository
    {
        Task<ActionResult<IEnumerable<Location>>> GetListLocation();
        Task<ActionResult<IEnumerable<Location>>> GetAllTrackingsDriverForUserManager(long userManagerId, long driverid);
        Task<ActionResult<IEnumerable<Location>>> GetAllDriversTrackingsForUserManager(long userManagerId);
        Task<ActionResult<IEnumerable<Location>>> GetAllTrackingsCarForUserManager(long userManagerId, long carId);
        Task<ActionResult<IEnumerable<Location>>> GetAllTrackingsForDriver(long userid);
        Task<ActionResult<IEnumerable<Location>>> GetTrackingForDriver(long userid,long locationId);

        /*
         * For Super User
         */
        Task<ActionResult<IEnumerable<Location>>> GetAllTrackings();
        Task<ActionResult<Tracks>> SaveTracking(Tracks tracks);

        
        Task<ActionResult<Location>> GetLocation(long id);
        Task<ActionResult<Location>> PostLocation(Location location);
        Task<ActionResult<Location>> DeleteLocation(long id);
        bool LocationExists(long id);
    }
}
