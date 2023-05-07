
using Data.Entities;
using System.Collections.Generic;
using System.Data;

namespace Data.Interfaces 
{
    public interface IProductImageRepository
    {
        ProductImage Add(ProductImage productImage);
        ProductImage Get(int id);
        List<ProductImage> GetAll();
        void Dispose();

    }
}