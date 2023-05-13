
using Data.Entities;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IProductPackingRepository
    {
        ProductPacking Add(ProductPacking productPacking);
        List<ProductPacking> AddRange(List<ProductPacking> productPacking);
        ProductPacking Get(int id);
        List<ProductPacking> GetAll();
        void Dispose();

    }
}