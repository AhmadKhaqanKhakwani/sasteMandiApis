using Data.Context;
using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Data.Repositories
{
    public class ProductImagesRepository : IDisposable, IProductImagesRepository
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
                using (var _context = Db.Create())
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
                    return _context.ProductImages.Where(u => u.IsActive == true).ToList();

                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        //Update image

        public ProductImage UpdateSlider(ProductImage image)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.ProductImages.Update(image);
                    _context.SaveChanges();

                }

                return image;

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

                var currentImage = _context.ProductImages.Find(id);
                if (currentImage != null)
                {
                    currentImage.IsActive = false;
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
