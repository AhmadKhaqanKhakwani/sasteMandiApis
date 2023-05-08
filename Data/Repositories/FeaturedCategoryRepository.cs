using Data.Context;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Data.Repositories
{
    public class FeaturedCategoryRepository : IDisposable, IFeaturedCategoryRepository
    {
        public FeaturedCategory Add(FeaturedCategory FeaturedCategory)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.FeaturedCategories.Add(FeaturedCategory);
                    _context.SaveChanges();
                }

                return FeaturedCategory;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public FeaturedCategory Update(FeaturedCategory FeaturedCategory)
        {
            try
            {
                var isExist = Get(FeaturedCategory.Id);
                if (isExist != null)
                {
                    using (var _context = Db.Create())
                    {
                        _context.FeaturedCategories.Update(FeaturedCategory);
                        _context.SaveChanges();

                    }

                    return FeaturedCategory;

                }
                else return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public FeaturedCategory Get(int id)
        {
            try
            {
                using (var _context = Db.Create())
                {

                    return _context.FeaturedCategories.Find(id);

                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<FeaturedCategory> GetAll()
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.FeaturedCategories.Include(u => u.SubCategories).Where(u => u.IsActive == true).ToList();

                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public bool DeleteFeaturedCategory(int id)
        {
            using(var _context = Db.Create())
            {
                var currentFeatured= _context.FeaturedCategories.Find(id);
                if (currentFeatured != null)
                {
                    currentFeatured.IsActive = false;
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
