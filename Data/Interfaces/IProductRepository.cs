
using Data.Entities;
using System.Collections.Generic;
using System.Data;

namespace Data.Interfaces 
{
    public interface IPackageDetailRepository
    {
        PackageDetail Add(PackageDetail packageDetail);
        PackageDetail Get(int id);
        List<PackageDetail> GetAll();
        void Dispose();

    }
}