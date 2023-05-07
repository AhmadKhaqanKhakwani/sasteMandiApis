
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
    public class ProductImageRepository : IDisposable, IProductImageRepository
    {
        public ProductImage Add(ProductImage productImage)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.ProductImages.Add(productImage);
                    _context.SaveChanges();
                }

                return productImage;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ProductImage Get(int id)
        {
            try
            {
                using(var _context = Db.Create())
                {
                    
                return _context.ProductImages.Find(id);

                }

            }
            catch (Exception ex)
            {
                return null;
            }
          
        }
        public List<ProductImage> GetAll()
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.ProductImages.Where(u=>u.IsActive == true).ToList();

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
