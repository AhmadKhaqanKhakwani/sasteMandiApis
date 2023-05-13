
using Data.Entities;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IProductToSubCategoryRepository
    {
        SubCategoryToProduct Add(SubCategoryToProduct SubCategoryToProduct);
        SubCategoryToProduct Get(int id);
        List<SubCategoryToProduct> GetAll();
        List<SubCategoryToProduct> AddList(List<SubCategoryToProduct> subCategoryToProducts);
        void Dispose();

    }
}