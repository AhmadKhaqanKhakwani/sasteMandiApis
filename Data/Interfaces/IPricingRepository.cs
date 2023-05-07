
using Data.Entities;
using System.Collections.Generic;
using System.Data;

namespace Data.Interfaces 
{
    public interface IPricingRepository
    {
        Pricing Add(Pricing pricingRepository);
        Pricing Get(int id);
        List<Pricing> GetAll();
        void Dispose();

    }
}