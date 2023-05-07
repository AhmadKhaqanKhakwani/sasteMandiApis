
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
    public class StockEntityTypeRepository : IDisposable, IStockEntityTypeRepository
    {
        public StockEntityType Add(StockEntityType stockEntityType)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.StockEntityTypes.Add(stockEntityType);
                    _context.SaveChanges();
                }

                return stockEntityType;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public StockEntityType Get(int id)
        {
            try
            {
                using(var _context = Db.Create())
                {
                    
                return _context.StockEntityTypes.Find(id);

                }

            }
            catch (Exception ex)
            {
                return null;
            }
          
        }
        public List<StockEntityType> GetAll()
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.StockEntityTypes.Where(u=>u.IsActive == "true").ToList();

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
