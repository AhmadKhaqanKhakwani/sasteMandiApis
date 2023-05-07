
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
    public class ColsedStockRepository : IDisposable, IColsedStockRepository
    {
        public ColsedStock Add(ColsedStock colsedStock)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.ColsedStocks.Add(colsedStock);
                    _context.SaveChanges();
                }

                return colsedStock;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ColsedStock Get(int id)
        {
            try
            {
                using(var _context = Db.Create())
                {
                    return _context.ColsedStocks.Find(id);
                }

            }
            catch (Exception ex)
            {
                return null;
            }
          
        }
        public List<ColsedStock> GetAll()
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.ColsedStocks.Where(u=>u.IsActive == true).ToList();

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
