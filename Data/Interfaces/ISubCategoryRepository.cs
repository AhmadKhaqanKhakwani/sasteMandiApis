
using Data.Entities;
using System.Collections.Generic;
using System.Data;

namespace Data.Interfaces 
{
    public interface ISubCategoryRepository
    {
        SubCategory Add(SubCategory stock);
        List<SubCategory> AddRange(List<SubCategory> SubCategory);
        SubCategory Update(SubCategory SubCategory);
        SubCategory Get(int id);
        List<SubCategory> GetAll();
        List<SubCategory> GetByFeaturedId(int featuredCategoryId);
        bool Delete(int subCategoryId);
        void Dispose();

    }
}