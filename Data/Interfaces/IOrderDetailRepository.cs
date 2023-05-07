
using Data.Entities;
using System.Collections.Generic;
using System.Data;

namespace Data.Interfaces 
{
    public interface IOrderDetailRepository
    {
        OrderDetail Add(OrderDetail orderDetail);
        OrderDetail Get(int id);
        List<OrderDetail> GetAll();
        void Dispose();

    }
}