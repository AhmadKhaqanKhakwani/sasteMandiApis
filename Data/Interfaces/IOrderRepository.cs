
using Data.Entities;
using System.Collections.Generic;
using System.Data;

namespace Data.Interfaces 
{
    public interface IOrderRepository
    {
        Order Add(Order order);
        Order Get(int id);
        List<Order> GetAll();
        void Dispose();

    }
}