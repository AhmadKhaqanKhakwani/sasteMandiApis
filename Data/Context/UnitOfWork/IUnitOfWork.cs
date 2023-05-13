using Data.Interfaces;
using Data.Repositories;

namespace Data.Context.UnitOfWork
{

    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        ISliderRepository SliderRepository { get; }
        IFeaturedCategoryRepository FeaturedCategoryRepository { get; }
        ISubCategoryRepository SubCategoryRepository { get; }
        IPricingRepository PricingRepository { get; }
        IPackageRepository PackageRepository { get; }
        IPackageDetailRepository PackageDetailRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderDetailRepository OrderDetailRepository { get; }
        ILocationRepository LocationRepository { get; }
        IAddressRepository AddressRepository { get; }
        IProductToSubCategoryRepository ProductToSubCategoryRepository { get; }
        IProductPackingRepository ProductPackingRepository { get; }
        IProductImageRepository ProductImageRepository { get; }


    }
}
