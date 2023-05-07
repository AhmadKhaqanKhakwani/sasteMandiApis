
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
    public class StockRepository : IDisposable, IStockRepository
    {
        public Stock Add(Stock stock)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.Stocks.Add(stock);
                    _context.SaveChanges();
                }

                return stock;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Stock Get(int id)
        {
            try
            {
                using(var _context = Db.Create())
                {
                    
                return _context.Stocks.Find(id);

                }

            }
            catch (Exception ex)
            {
                return null;
            }
          
        }
        public List<Stock> GetAll()
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.Stocks.Where(u=>u.IsActive == true).ToList();

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
