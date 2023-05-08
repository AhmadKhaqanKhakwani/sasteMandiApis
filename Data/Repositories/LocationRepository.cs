using Data.Context;
using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

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
                using (var _context = Db.Create())
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
                    return _context.Locations.Where(u => u.IsActive == true).ToList();

                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }


        public Location Update(Location location)
        {
            try
            {

                using (var _context = Db.Create())
                {
                    _context.Locations.Update(location);
                    _context.SaveChanges();
                }
                return location;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Delete(int id)
        {

            using (var _context = Db.Create())
            {

                var currentSlider = _context.Locations.Find(id);
                if (currentSlider != null)
                {
                    currentSlider.IsActive = false;
                    _context.SaveChanges();
                    return true;
                }
                else return false;
            }

        }
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

    }
}
