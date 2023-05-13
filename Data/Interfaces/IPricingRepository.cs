
using Data.Entities;
using System.Collections.Generic;
using System.Data;

namespace Data.Interfaces 
{
    public interface IPricingRepository
    {
        Pricing Add(Pricing pricingRepository);
        List<Pricing> AddRange(List<Pricing> pricings);
        Pricing Get(int id);
        List<Pricing> GetAll();
        List<Pricing> GetAllByIds(List<int> ids);
        void Dispose();

    }
}