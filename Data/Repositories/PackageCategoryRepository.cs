
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
    public class PackageCategoryRepository : IDisposable, IPackageCategoryRepository
    {
        public PackageCategory Add(PackageCategory packageCategory)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.PackageCategories.Add(packageCategory);
                    _context.SaveChanges();
                }

                return packageCategory;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public PackageCategory Get(int id)
        {
            try
            {
                using(var _context = Db.Create())
                {
                    
                return _context.PackageCategories.Find(id);

                }

            }
            catch (Exception ex)
            {
                return null;
            }
          
        }
        public List<PackageCategory> GetAll()
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.PackageCategories.Where(u=>u.IsActive == true).ToList();

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
