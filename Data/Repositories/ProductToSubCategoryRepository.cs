using Data.Context;
using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Data.Repositories
{
    public class ProductToSubCategoryRepository : IDisposable, IProductToSubCategoryRepository
    {
        public SubCategoryToProduct Add(SubCategoryToProduct SubCategoryToProduct)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.SubCategoryToProducts.Add(SubCategoryToProduct);
                    _context.SaveChanges();
                }

                return SubCategoryToProduct;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<SubCategoryToProduct> AddList(List<SubCategoryToProduct> subCategoryToProducts)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.SubCategoryToProducts.AddRange(subCategoryToProducts);
                    _context.SaveChanges();
                }

                return subCategoryToProducts;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public SubCategoryToProduct Get(int id)
        {
            try
            {
                using (var _context = Db.Create())
                {

                    return _context.SubCategoryToProducts.Find(id);

                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<SubCategoryToProduct> GetAll()
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.SubCategoryToProducts.Where(u => u.IsActive == true).ToList();

                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        //Update SubCategoryToProduct

        public SubCategoryToProduct UpdateSubCategoryToProduct(SubCategoryToProduct SubCategoryToProduct)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.SubCategoryToProducts.Update(SubCategoryToProduct);
                    _context.SaveChanges();

                }

                return SubCategoryToProduct;

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public bool DeleteSubCategoryToProduct(int id)
        {

            using (var _context = Db.Create())
            {

                var currentSubCategoryToProduct = _context.SubCategoryToProducts.Find(id);
                if (currentSubCategoryToProduct != null)
                {
                    currentSubCategoryToProduct.IsActive = false;
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
