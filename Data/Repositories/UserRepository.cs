using Data.Models;
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
    public class UserRepository : IDisposable, IUserRepository
    {
        public User Add(User user)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.Add(user);
                    _context.SaveChanges();
                }

                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public User Update(User user)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.Update(user);
                    _context.SaveChanges();
                }

                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Delete(List<int> userIds)
        {
            try
            {
                using (var _context = Db.Create())
                {

                    var user = _context.Users.Where(o => userIds.Contains(o.Id)).ToList();

                    if (user.Count == 0)
                    {
                        return false;
                    }
                    _context.RemoveRange(user);
                    _context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public User Get(int id)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return new User();
                    //return _context.Users.FirstOrDefault(o => o.Id == id);
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
