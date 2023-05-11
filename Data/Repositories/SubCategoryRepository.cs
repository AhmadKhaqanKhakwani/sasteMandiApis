
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

        public List<SubCategory> AddRange(List<SubCategory> SubCategory)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.SubCategories.AddRange(SubCategory);
                    _context.SaveChanges();
                }

                return SubCategory;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public SubCategory Update(SubCategory SubCategory)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.SubCategories.Update(SubCategory);
                    _context.SaveChanges();
                }

                return SubCategory;
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

        public List<SubCategory> GetByFeaturedId(int featuredCategoryId)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.SubCategories.Where(u => u.IsActive == true && u.FeaturedCategoryId == featuredCategoryId).ToList();

                }

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
                var currentCategory = _context.SubCategories.Find(id);
                if (currentCategory != null)
                {
                    currentCategory.IsActive = false;
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
