
using Data.Utils;
using Utility.Commons;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Data.Interfaces;
using Data.Context;
using Data.Entities;

namespace Data.Repositories
{
    public class OrderDetailRepository : IDisposable, IOrderDetailRepository
    {
        public OrderDetail Add(OrderDetail orderDetail)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.OrderDetails.Add(orderDetail);
                    _context.SaveChanges();
                }

                return orderDetail;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public OrderDetail Get(int id)
        {
            try
            {
                using(var _context = Db.Create())
                {
                    
                return _context.OrderDetails.Find(id);

                }

            }
            catch (Exception ex)
            {
                return null;
            }
          
        }
        public List<OrderDetail> GetAll()
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.OrderDetails.Where(u=>u.IsActive == true).ToList();

                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
