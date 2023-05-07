
using Data.Entities;
using System.Collections.Generic;
using System.Data;

namespace Data.Interfaces 
{
    public interface IOrderEntityTypeRepository
    {
        OrderEntityType Add(OrderEntityType orderEntityType);
        OrderEntityType Get(int id);
        List<OrderEntityType> GetAll();
        void Dispose();

    }
}