using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using TrackLocation.Hubs;
using TrackLocation.IRepository;
using TrackLocation.Model;


namespace TrackLocation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLocationsController : ControllerBase
    {
        private readonly ILocationsRepository _repository;
        private readonly IUserLocationsRepository _user_repository;

        private readonly IHubContext<TrackHub> _hub;

        public UserLocationsController(ILocationsRepository repository,
                                       IUserLocationsRepository user_repository,
                                       IHubContext<TrackHub> hub)
        {
            _repository = repository;
            _hub = hub;
            _user_repository = user_repository;
        }



        //Real Time Show For User Manager
        [HttpGet("/track/{userManagerId}")]
        public async Task<ActionResult<IEnumerable<Location>>> GetAllDriversTrackingsForUserManager(long userManagerId)
        {
            var data = await _repository.GetAllDriversTrackingsForUserManager(userManagerId);
            var timerManager = new TimerManager(async () => await _hub.Clients.All.SendAsync("getDriversTracking", data));
            return Ok(data);

        }


        //Real Time Show For Conducteur
        [HttpGet("/track/{userid}")]
        public async Task<ActionResult<IEnumerable<Location>>> GetTrackingForDriver(long userid)
        {
            var data = await _repository.GetTrackingForDriver(userid);
            var timerManager = new TimerManager(async () => await _hub.Clients.All.SendAsync("getDriverTracking", data));
            return Ok(data);

        }
        /*
         *  Get All Trackings Driver To UserManager
         * 
         */
        [HttpGet("{userManagerId}/driver/{driverid}")]
        public async Task<ActionResult<IEnumerable<Location>>> GetAllTrackingsDriverForUserManager(long userManagerId, long driverid)
        {
            var data = await _repository.GetAllTrackingsDriverForUserManager(userManagerId, driverid);
            return Ok(data); 
        }

        /*
         *  Get All Trackings Car For UserManager
         * 
         */
        [HttpGet("{userManagerId}/car/{carId}")]
        public async Task<ActionResult<IEnumerable<Location>>> GetAllTrackingsCarForUserManager(long userManagerId, long carId)
        {
            var data = await _repository.GetAllTrackingsCarForUserManager(userManagerId,carId);
            return Ok(data);
            
        }
        /*
         *  Get All Trackings For Driver (Conducteur)
         * 
         */
        [HttpGet("/driver/{userid}")]
        public async Task<ActionResult<IEnumerable<Location>>> GetAllTrackingsForDriver(long userid)
        {
            var data = await _repository.GetAllTrackingsForDriver(userid);
            return Ok(data);

        }


        [HttpPost("/driver_tracking")]
        public async Task<ActionResult<Tracks>> SaveTracking(Tracks tracks)
        {
            return await _repository.SaveTracking(tracks);
        }

        [HttpDelete("{userid}/track/{locId}")]
        public async Task<ActionResult<Location>> DeleteUserLocation(long userid, long locId)
        {
            return await _user_repository.DeleteUserLocation(userid, locId);
        }


    }
}
