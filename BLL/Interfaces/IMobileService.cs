using BLL.Dtos.Mobile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IMobileService 
    {
        List<FeaturedCategoryDto> getPublicMainView();
        List<SliderDto> getSlider();
        List<PublicProductDto> getProducts();
        List<PublicPackageDto> getPackages();
        List<LocationDto> getLocations();

    }
}
