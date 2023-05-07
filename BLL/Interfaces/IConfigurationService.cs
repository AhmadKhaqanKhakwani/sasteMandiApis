using BLL.Dtos.Mobile;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IConfigurationService
    {
        bool Savefeaturedcategories(FeaturedCategoryDto featuredCategoryDto);
        List<SliderDto> GetAllSlider();
        bool AddOrUpdateSlider(SliderDto sliderDto);
        bool DeleteSlider(int id);

        // FeaturedCategory work
        bool AddOrEditFeaturedCategory(FeaturedCategoryDto featuredCategoryDto);
        List<FeaturedCategoryDto> GetAllFeaturedCategory();
        bool DeleteFeaturedCategory(int id);
    }
}
