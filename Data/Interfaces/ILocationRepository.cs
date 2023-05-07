
using Data.Entities;
using System.Collections.Generic;
using System.Data;

namespace Data.Interfaces 
{
    public interface ILocationRepository
    {
        Location Add(Location location);
        Location Get(int id);
        List<Location> GetAll();
        void Dispose();

    }
}