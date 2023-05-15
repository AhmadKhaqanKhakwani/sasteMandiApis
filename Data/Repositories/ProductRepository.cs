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
    public class ProductRepository : IDisposable, IProductRepository
    {
        public Product Add(Product product)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.Products.Add(product);
                    _context.SaveChanges();
                }

                return product;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Product Get(int id)
        {
            try
            {
                using (var _context = Db.Create())
                {

                    return _context.Products.Find(id);

                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<Product> GetAll()
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.Products.Where(u => u.IsActive == true).Include(u => u.ProductPackings).Include(u => u.SubCategoryToProducts).Include(u => u.ProductImages).ToList();

                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<Product> GetAllFiltered(int featuredCategoryId, int SubCategoryId)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.Products.Where(u => u.IsActive == true && u.FeaturedCategoryId == featuredCategoryId && u.SubCategoryToProducts.Select(u => u.SubCategoryId).Contains(SubCategoryId))
                        .Include(u => u.ProductPackings).Include(u => u.SubCategoryToProducts).Include(u => u.ProductImages).ToList();

                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<Product> GetAllProducts()
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.Products.Where(u => u.IsActive == true)
                        .Include(u => u.ProductPackings).Include(u => u.SubCategoryToProducts).Include(u => u.ProductImages).ToList();
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<Product> GetAllByIds(List<int> productIds)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.Products.Where(u => u.IsActive == true && productIds.Contains(u.Id)).Include(u => u.ProductPackings).Include(u => u.SubCategoryToProducts).Include(u => u.ProductImages).ToList();

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
