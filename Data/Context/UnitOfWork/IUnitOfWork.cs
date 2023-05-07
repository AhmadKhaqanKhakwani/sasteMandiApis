using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
