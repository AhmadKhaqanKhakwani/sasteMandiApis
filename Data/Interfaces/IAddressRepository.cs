
using Data.Entities;
using System.Collections.Generic;
using System.Data;

namespace Data.Interfaces 
{
    public interface IAddressRepository
    {
        Address Add(Address slider);
        Address Get(int id);
        List<Address> GetAll();
        Address UpdateAddress(Address slider);
        bool DeleteAddress(int id);
        void Dispose();

    }
}