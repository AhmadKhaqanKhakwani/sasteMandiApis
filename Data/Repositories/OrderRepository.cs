
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
    public class OrderRepository : IDisposable, IOrderRepository
    {
        public Order Add(Order order)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.Orders.Add(order);
                    _context.SaveChanges();
                }

                return order;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Order Get(int id)
        {
            try
            {
                using(var _context = Db.Create())
                { 
                    return _context.Orders.Find(id);
                }

            }
            catch (Exception ex)
            {
                return null;
            }
          
        }
        public List<Order> GetAll()
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.Orders.Where(u => u.IsActive == true).ToList();
;               }

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
