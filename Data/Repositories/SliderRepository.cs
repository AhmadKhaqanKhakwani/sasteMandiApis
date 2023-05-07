using Data.Context;
using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Data.Repositories
{
    public class SliderRepository : IDisposable, ISliderRepository
    {
        public Slider Add(Slider Slider)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.Sliders.Add(Slider);
                    _context.SaveChanges();
                }

                return Slider;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Slider Get(int id)
        {
            try
            {
                using (var _context = Db.Create())
                {

                    return _context.Sliders.Find(id);

                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<Slider> GetAll()
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.Sliders.Where(u => u.IsActive == true).ToList();

                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        //Update Slider

        public Slider UpdateSlider(Slider slider)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.Sliders.Update(slider);
                    _context.SaveChanges();

                }

                return slider;

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public bool DeleteSlider(int id)
        {

            using (var _context = Db.Create())
            {

                var currentSlider = _context.Sliders.Find(id);
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
