
using Data.Entities;
using System.Collections.Generic;
using System.Data;

namespace Data.Interfaces 
{
    public interface IProductDescriptionRepository
    {
        ProductDescription Add(ProductDescription productDescription);
        ProductDescription Get(int id);
        List<ProductDescription> GetAll();
        void Dispose();

    }
}