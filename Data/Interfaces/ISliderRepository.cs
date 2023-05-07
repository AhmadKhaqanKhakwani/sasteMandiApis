
using Data.Entities;
using System.Collections.Generic;
using System.Data;

namespace Data.Interfaces 
{
    public interface ISliderRepository
    {
        Slider Add(Slider slider);
        Slider Get(int id);
        List<Slider> GetAll();
        Slider UpdateSlider(Slider slider);
        bool DeleteSlider(int id);
        void Dispose();

    }
}