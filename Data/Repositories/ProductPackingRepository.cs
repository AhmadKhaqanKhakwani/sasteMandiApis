
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
    public class ProductPackingRepository : IDisposable, IProductPackingRepository
    {
        public ProductPacking Add(ProductPacking productPacking)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.ProductPackings.Add(productPacking);
                    _context.SaveChanges();
                }

                return productPacking;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public List<ProductPacking> AddRange(List<ProductPacking> productPacking)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.ProductPackings.AddRange(productPacking);
                    _context.SaveChanges();
                }

                return productPacking;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ProductPacking Get(int id)
        {
            try
            {
                using(var _context = Db.Create())
                {
                    
                return _context.ProductPackings.Find(id);

                }

            }
            catch (Exception ex)
            {
                return null;
            }
          
        }
        public List<ProductPacking> GetAll()
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.ProductPackings.Where(u=>u.IsActive == true).ToList();

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
