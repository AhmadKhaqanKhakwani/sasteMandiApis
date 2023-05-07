
using Data.Entities;
using System.Collections.Generic;
using System.Data;

namespace Data.Interfaces 
{
    public interface IProductPackingRepository
    {
        ProductPacking Add(ProductPacking productPacking);
        ProductPacking Get(int id);
        List<ProductPacking> GetAll();
        void Dispose();

    }
}