
using Data.Entities;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IFeaturedCategoryRepository
    {
        FeaturedCategory Add(FeaturedCategory featuredCategory);
        FeaturedCategory Update(FeaturedCategory featuredCategory);
        FeaturedCategory Get(int id);
        List<FeaturedCategory> GetAll();
        bool DeleteFeaturedCategory(int id);
        void Dispose();

    }
}