﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackLocation.IRepository;
using TrackLocation.Model;

namespace TrackLocation.Repository
{
    public class UsersRepository : IUsersRepository
    {
        public readonly TrackLocationContext _context;
        public UsersRepository(TrackLocationContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<User>> DeleteUser(long id)
        {
            var user = await _context.User.FindAsync(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<ActionResult<User>> GetUser(long id)
        {
            var user = await _context.User.FindAsync(id);
            return user;
        }

        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<ActionResult<User>> PutUser(long id, User user)
        {
            if (id != user.UserId) return null;
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<ActionResult<IEnumerable<User>>> getAllUserManagerForSuperUser(long super_user_id, string typeUser)
        {
            var listeUserManager = await _context.User.Where(c => c.UserId == super_user_id)
                                                .Where(u => u.TypeUser == typeUser)
                                                .Where(x => x.CreatedByAdminID == super_user_id).ToListAsync();
            return listeUserManager;
        }
        public async Task<ActionResult<IEnumerable<User>>> getAllDriversForUserManager(long user_manager_id, string typeUser)
        {
            var listedrivers = await _context.User.Where(c => c.UserId == user_manager_id)
                                                .Where(u => u.TypeUser == typeUser)
                                                .Where(x => x.CreatedByAdminID == user_manager_id).ToListAsync();
            return listedrivers;
        }
        public bool UserExists(long id)
        {
            return _context.User.Any(e => e.UserId == id);
        }
    }
}
