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

        SliderResult GetAllSlider();
        bool AddOrUpdateSlider(SliderDto sliderDto);
        bool DeleteSlider(int id);

        // featuredCategory work
        bool AddOrEditFeaturedCategory(FeaturedCategoryDto featuredCategoryDto);
        List<FeaturedCategoryDto> GetAllFeaturedCategory();
        bool DeleteFeaturedCategory(int id);

        // location work
        List<LocationDto> GetAllLocation();
        LocationDto GetLocation(int id);
        bool AddOrUpdateLocation(LocationDto locationDto);
        bool DeleteLocation(int id);

        // AddProduct work
        bool AddProduct(AddProductDto addProductDto);
    }
}
