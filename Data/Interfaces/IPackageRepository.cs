
using Data.Entities;
using System.Collections.Generic;
using System.Data;

namespace Data.Interfaces 
{
    public interface IPackageRepository
    {
        Package Add(Package package);
        Package Get(int id);
        List<Package> GetAll();
        List<Package> GetAllByIds(List<int> packageIds);
        void Dispose();

    }
}