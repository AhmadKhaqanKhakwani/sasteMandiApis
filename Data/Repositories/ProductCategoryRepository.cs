
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
    public class ProductCategoryRepository : IDisposable, IProductCategoryRepository
    {
        public ProductCategory Add(ProductCategory productCategory)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.ProductCategories.Add(productCategory);
                    _context.SaveChanges();
                }

                return productCategory;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ProductCategory Get(int id)
        {
            try
            {
                using(var _context = Db.Create())
                {
                    
                return _context.ProductCategories.Find(id);

                }

            }
            catch (Exception ex)
            {
                return null;
            }
          
        }
        public List<ProductCategory> GetAll()
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.ProductCategories.Where(u=>u.IsActive == true).ToList();

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
