
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
    public class OrderStatusRepository : IDisposable, IOrderStatusRepository
    {
        public OrderStatus Add(OrderStatus orderStatus)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.OrderStatuses.Add(orderStatus);
                    _context.SaveChanges();
                }

                return orderStatus;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public OrderStatus Get(int id)
        {
            try
            {
                using(var _context = Db.Create())
                {
                    
                return _context.OrderStatuses.Find(id);

                }

            }
            catch (Exception ex)
            {
                return null;
            }
          
        }
        public List<OrderStatus> GetAll()
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.OrderStatuses.Where(u=>u.IsActive == true).ToList();

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
