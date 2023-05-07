
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
    public class OrderEntityTypeRepository : IDisposable, IOrderEntityTypeRepository
    {
        public OrderEntityType Add(OrderEntityType orderEntityType)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.OrderEntityTypes.Add(orderEntityType);
                    _context.SaveChanges();
                }

                return orderEntityType;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public OrderEntityType Get(int id)
        {
            try
            {
                using(var _context = Db.Create())
                {
                    
                return _context.OrderEntityTypes.Find(id);

                }

            }
            catch (Exception ex)
            {
                return null;
            }
          
        }
        public List<OrderEntityType> GetAll()
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.OrderEntityTypes.Where(u=>u.IsActive == true).ToList();

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
