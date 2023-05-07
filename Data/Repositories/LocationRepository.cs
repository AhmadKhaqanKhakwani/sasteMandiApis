
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
    public class LocationRepository : IDisposable, ILocationRepository
    {
        public Location Add(Location Location)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.Locations.Add(Location);
                    _context.SaveChanges();
                }

                return Location;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Location Get(int id)
        {
            try
            {
                using(var _context = Db.Create())
                {
                    
                return _context.Locations.Find(id);

                }

            }
            catch (Exception ex)
            {
                return null;
            }
          
        }
        public List<Location> GetAll()
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.Locations.Where(u=>u.IsActive == true).ToList();

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
