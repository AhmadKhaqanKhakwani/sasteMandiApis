
using Data.Entities;
using System.Collections.Generic;
using System.Data;

namespace Data.Interfaces 
{
    public interface IColsedStockRepository
    {
        ColsedStock Add(ColsedStock colsedStock);
        ColsedStock Get(int id);
        List<ColsedStock> GetAll();
        void Dispose();

    }
}