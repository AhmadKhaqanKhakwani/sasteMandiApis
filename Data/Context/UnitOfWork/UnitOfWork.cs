using Data.Interfaces;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IProductRepository _productRepository;
        private ISliderRepository _sliderRepository;
        private IFeaturedCategoryRepository _featuredCategoryRepository;
        private ISubCategoryRepository _subCategoryRepository;
        private IPricingRepository _pricingRepository;
        private IPackageRepository _packageRepository;
        private IPackageDetailRepository _packageDetailRepository;
        private IOrderRepository _orderRepository;
        private IOrderDetailRepository _orderDetailRepository;
        private ILocationRepository _locationRepository;


        public ILocationRepository LocationRepository
        {
            get
            {
                return _locationRepository ??= new LocationRepository();
            }
        }

        public IOrderRepository OrderRepository
        {
            get
            {
                return _orderRepository ??= new OrderRepository();
            }
        }
        public IOrderDetailRepository OrderDetailRepository
        {
            get
            {
                return _orderDetailRepository ??= new OrderDetailRepository();
            }
        }

        public IPackageRepository PackageRepository
        {
            get
            {
                return _packageRepository ??= new PackageRepository();
            }
        }
        public IPackageDetailRepository PackageDetailRepository
        {
            get
            {
                return _packageDetailRepository ??= new PackageDetailRepository();
            }
        }
        public IProductRepository ProductRepository
        {
            get
            {
                return _productRepository ??= new ProductRepository();
            }
        }
        public ISliderRepository SliderRepository
        {
            get
            {
                return _sliderRepository ??= new SliderRepository();
            }
        }
        public IFeaturedCategoryRepository FeaturedCategoryRepository
        {
            get
            {
                return _featuredCategoryRepository ??= new FeaturedCategoryRepository();
            }
        }
        public ISubCategoryRepository SubCategoryRepository
        {
            get
            {
                return _subCategoryRepository ??= new SubCategoryRepository();
            }
        }
        public IPricingRepository PricingRepository
        {
            get
            {
                return _pricingRepository ??= new PricingRepository();
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                   // _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
