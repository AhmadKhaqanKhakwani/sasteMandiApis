
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
    public class PackageDetailRepository : IDisposable, IPackageDetailRepository
    {
        public PackageDetail Add(PackageDetail packageDetail)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.PackageDetails.Add(packageDetail);
                    _context.SaveChanges();
                }

                return packageDetail;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public PackageDetail Get(int id)
        {
            try
            {
                using(var _context = Db.Create())
                {
                    
                return _context.PackageDetails.Find(id);

                }

            }
            catch (Exception ex)
            {
                return null;
            }
          
        }
        public List<PackageDetail> GetAll()
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.PackageDetails.Where(u=>u.IsActive == true).ToList();

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
