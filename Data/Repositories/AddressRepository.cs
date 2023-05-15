using Data.Context;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Data.Repositories
{
    public class AddressRepository : IDisposable, IAddressRepository
    {
        public Address Add(Address Slider)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.Addresses.Add(Slider);
                    _context.SaveChanges();
                }

                return Slider;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<Address> UpdateList(List<Address> Address)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.Addresses.UpdateRange(Address);
                    _context.SaveChanges();
                }

                return Address;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Address Get(int id)
        {
            try
            {
                using (var _context = Db.Create())
                {

                    return _context.Addresses.Find(id);

                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<Address> GetAll()
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.Addresses.Where(u => u.IsActive == true).Include(u=>u.Location).ToList();

                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        //Update Address

        public Address UpdateAddress(Address slider)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.Addresses.Update(slider);
                    _context.SaveChanges();

                }

                return slider;

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public bool DeleteAddress(int id)
        {

            using (var _context = Db.Create())
            {

                var currentSlider = _context.Addresses.Find(id);
                if (currentSlider != null)
                {
                    currentSlider.IsActive = false;
                    _context.SaveChanges();
                    return true;
                }
                else return false;
            }

        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

    }
}
