
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
    public class ProductDescriptionRepository : IDisposable, IProductDescriptionRepository
    {
        public ProductDescription Add(ProductDescription productDescription)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.ProductDescriptions.Add(productDescription);
                    _context.SaveChanges();
                }

                return productDescription;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ProductDescription Get(int id)
        {
            try
            {
                using(var _context = Db.Create())
                {
                    
                return _context.ProductDescriptions.Find(id);

                }

            }
            catch (Exception ex)
            {
                return null;
            }
          
        }
        public List<ProductDescription> GetAll()
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.ProductDescriptions.Where(u=>u.IsActive == true).ToList();

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
