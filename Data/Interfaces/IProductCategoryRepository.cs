
using Data.Entities;
using System.Collections.Generic;
using System.Data;

namespace Data.Interfaces 
{
    public interface IProductCategoryRepository
    {
        ProductCategory Add(ProductCategory productCategory);
        ProductCategory Get(int id);
        List<ProductCategory> GetAll();
        void Dispose();

    }
}