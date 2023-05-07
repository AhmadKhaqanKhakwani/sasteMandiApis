
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
    public class SubCategoryRepository : IDisposable, ISubCategoryRepository
    {
        public  SubCategory Add( SubCategory  SubCategory)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.SubCategories.Add( SubCategory);
                    _context.SaveChanges();
                }

                return  SubCategory;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public  SubCategory Get(int id)
        {
            try
            {
                using(var _context = Db.Create())
                {
                    
                return _context.SubCategories.Find(id);

                }

            }
            catch (Exception ex)
            {
                return null;
            }
          
        }
        public List< SubCategory> GetAll()
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.SubCategories.Where(u=>u.IsActive == true).ToList();

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
