
using Data.Utils;
using Utility.Commons;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Data.Interfaces;
using Data.Context;
using Data.Entities;

namespace Data.Repositories
{
    public class UserProfileRepository : IDisposable, IUserProfileRepository
    {
        public UserProfile Add(UserProfile userProfile)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.UserProfiles.Add(userProfile);
                    _context.SaveChanges();
                }

                return userProfile;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public UserProfile Get(int id)
        {
            try
            {
                using(var _context = Db.Create())
                {
                    
                return _context.UserProfiles.Find(id);

                }

            }
            catch (Exception ex)
            {
                return null;
            }
          
        }
        public List<UserProfile> GetAll()
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.UserProfiles.Where(u=>u.IsActive == true).ToList();

                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

    }
}
