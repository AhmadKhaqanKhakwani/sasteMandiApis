
using Data.Entities;
using System.Collections.Generic;
using System.Data;

namespace Data.Interfaces 
{
    public interface IOrderStatusRepository
    {
        OrderStatus Add(OrderStatus orderStatus);
        OrderStatus Get(int id);
        List<OrderStatus> GetAll();
        void Dispose();

    }
}