
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
    public class PackageRepository : IDisposable, IPackageRepository
    {
        public Package Add(Package package)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.Packages.Add(package);
                    _context.SaveChanges();
                }

                return package;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Package Get(int id)
        {
            try
            {
                using(var _context = Db.Create())
                {
                    return _context.Packages.Find(id);
                }

            }
            catch (Exception ex)
            {
                return null;
            }
          
        }
        public List<Package> GetAll()
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.Packages.Where(u=>u.IsActive == true).Include(u=>u.PackageDetails).ToList();

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
