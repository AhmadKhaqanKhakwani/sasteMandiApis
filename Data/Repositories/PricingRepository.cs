﻿using Data.Context;
using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Data.Repositories
{
    public class PricingRepository : IDisposable, IPricingRepository
    {
        public Pricing Add(Pricing pricing)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.Pricings.Add(pricing);
                    _context.SaveChanges();
                }
                return pricing;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<Pricing> AddRange(List<Pricing> pricing)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.Pricings.AddRange(pricing);
                    _context.SaveChanges();
                }
                return pricing;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Pricing Get(int id)
        {
            try
            {
                using (var _context = Db.Create())
                {

                    return _context.Pricings.Find(id);

                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<Pricing> GetAll()
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.Pricings.Where(u => u.IsActive == true).ToList();

                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<Pricing> GetAllByIds(List<int> ids)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.Pricings.Where(u => u.IsActive == true && ids.Contains(u.Id)).ToList();

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
