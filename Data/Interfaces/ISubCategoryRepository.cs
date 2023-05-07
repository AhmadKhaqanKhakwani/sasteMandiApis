
using Data.Entities;
using System.Collections.Generic;
using System.Data;

namespace Data.Interfaces 
{
    public interface ISubCategoryRepository
    {
        SubCategory Add(SubCategory stock);
        SubCategory Get(int id);
        List<SubCategory> GetAll();
        void Dispose();

    }
}