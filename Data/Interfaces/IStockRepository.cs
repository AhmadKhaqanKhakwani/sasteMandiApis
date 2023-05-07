
using Data.Entities;
using System.Collections.Generic;
using System.Data;

namespace Data.Interfaces 
{
    public interface IStockRepository
    {
        Stock Add(Stock stock);
        Stock Get(int id);
        List<Stock> GetAll();
        void Dispose();

    }
}