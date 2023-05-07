
using Data.Entities;
using System.Collections.Generic;
using System.Data;

namespace Data.Interfaces 
{
    public interface IPackageCategoryRepository
    {
        PackageCategory Add(PackageCategory packageCategory);
        PackageCategory Get(int id);
        List<PackageCategory> GetAll();
        void Dispose();

    }
}