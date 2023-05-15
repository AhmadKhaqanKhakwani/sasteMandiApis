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
        List<PublicProductDto> getProducts(int featuredCategoryId, int SubCategoryId);
        List<PublicPackageDto> getPackages();
        List<LocationDto> getLocations();

        // Placeorder
        bool placeOrder(CreateOrderDto createOrderDto);
        bool addAddress(AddressDto addressDto);
        List<AddressDto> getAddress();
        bool addDefeaultAddress(int addressId);
        bool deleteAddress(int id);

    }
}
