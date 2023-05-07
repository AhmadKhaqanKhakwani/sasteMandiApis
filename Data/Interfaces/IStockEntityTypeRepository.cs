
using Data.Entities;
using System.Collections.Generic;
using System.Data;

namespace Data.Interfaces 
{
    public interface IStockEntityTypeRepository
    {
        StockEntityType Add(StockEntityType stockEntityType);
        StockEntityType Get(int id);
        List<StockEntityType> GetAll();
        void Dispose();

    }
}