
using Data.Entities;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IProductImagesRepository
    {
        ProductImage Add(ProductImage productImage);
        public ProductImage Get(int id);
        public List<ProductImage> GetAll();
        ProductImage UpdateSlider(ProductImage image);
        bool Delete(int id);
        void Dispose();

    }
}