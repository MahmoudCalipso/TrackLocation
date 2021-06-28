using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackLocation.Model;

namespace TrackLocation.IRepository
{
    public interface IUsersRepository
    {
        Task<ActionResult<IEnumerable<User>>> GetUser();
        Task<ActionResult<User>> GetUser(long id);
        Task<ActionResult<User>> PutUser(long id, User user);
        Task<ActionResult<User>> PostUser(User user);
        Task<ActionResult<User>> DeleteUser(long id);
        //  Define methode to get all user manager for super user 
        Task<ActionResult<IEnumerable<User>>> getAllUserManagerForSuperUser(long super_user_id, string typeUser);
        // Define methode to get all drivers for user manager 
        Task<ActionResult<IEnumerable<User>>> getAllDriversForUserManager(long user_manager_id , string typeUser);
        bool UserExists(long id);
    }
}
