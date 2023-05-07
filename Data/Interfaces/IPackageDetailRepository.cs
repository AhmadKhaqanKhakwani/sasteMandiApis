
using Data.Entities;
using System.Collections.Generic;
using System.Data;

namespace Data.Interfaces 
{
    public interface IProductRepository
    {
        Product Add(Product product);
        Product Get(int id);
        List<Product> GetAll();
        List<Product> GetAllByIds(List<int> productIds);
        void Dispose();

    }
}