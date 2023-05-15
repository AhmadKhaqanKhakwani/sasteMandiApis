using BLL.Dtos.Mobile;
using BLL.Interfaces;
using Data.Context.UnitOfWork;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Utility.Enumerations;

namespace BLL.Services
{
    public class MobileService : IMobileService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MobileService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;  
        }

        public List<PublicProductDto> getProducts(int featuredCategoryId, int SubCategoryId)
        {
            var products = _unitOfWork.ProductRepository.GetAllFiltered(featuredCategoryId,  SubCategoryId);

            var pricing = _unitOfWork.PricingRepository.GetAllByIds(products.Select(u => u.DeafultPriceId).ToList());
          
            var productDtos = new List<PublicProductDto>();

            foreach(var product in products)
            {
               var packingPricing = _unitOfWork.PricingRepository.GetAllByIds(product.ProductPackings.Select(u => u.PriceId).ToList());

                var productDto = new PublicProductDto()
                {
                    productId = product.Id,
                    textEng = product.TitleEng,
                    textUrdu = product.TitleUrdu,
                    imageUrl = product.ProductImages.FirstOrDefault()?.ImageUrl ?? "",
                    displayOrder = 1,
                    packaging = product.ProductPackings.Select(u => new PackagingDto() { packingId = u.Id, text = u.PackingTitle, price = (int)packingPricing.FirstOrDefault(p=> p.Id == u.PriceId).Amount, oldPrice = (int)packingPricing.FirstOrDefault(p => p.Id == u.PriceId).DiscountedAmount, isDeafult = false }).ToList(),
                    //categoryId = product.FeaturedCategoryId,
                    //subCategory = product.SubCategoryToProducts.Select(u => u.Id).ToList()
                };

                productDto.packaging.Add(new PackagingDto() { packingId = 0, text = "1 Kg", price = (int)pricing.FirstOrDefault(p => p.Id == product.DeafultPriceId).Amount, oldPrice = (int)pricing.FirstOrDefault(p => p.Id == product.DeafultPriceId).DiscountedAmount, isDeafult = true });
                productDtos.Add(productDto);
            } 

            return productDtos;
        }

        public List<PublicPackageDto> getPackages()
        {
            var packages = _unitOfWork.PackageRepository.GetAll();

            List<int> productIds = new List<int>();

            foreach (var package in packages)
            {
                productIds.AddRange(package.PackageDetails.Select(u => u.ProductId).ToList()); 
            }

            var products = _unitOfWork.ProductRepository.GetAllByIds(productIds);             

            var packageDtos = new List<PublicPackageDto>();

            foreach (var package in packages)
            {

                packageDtos.Add(
                new PublicPackageDto()
                {   packageId = package.Id,
                    title = package.PackageTitle,
                    totalPrice = package.PackageTotalPrice,
                    products = products.Where(u => package.PackageDetails.Select(u => u.ProductId).ToList().Contains(u.Id)).Select(u => new PublicProductDto().toPackageProductDTO(u, package.PackageDetails.ToList())).ToList()
                 }
                ) ;
             
            }

            return packageDtos;
        }

        public List<LocationDto> getLocations()
        {
            var locations = _unitOfWork.LocationRepository.GetAll();

            var locationDto = locations.Select(u => new LocationDto()
            {
                id = u.Id,
                title = u.Title
            }).ToList();


            return locationDto;
        }
        public List<SliderDto> getSlider()
        {
            var slider = _unitOfWork.SliderRepository.GetAll();

            var sliderDto = new List<SliderDto>();

            foreach (var sliderItem in slider)
            {
                sliderDto.Add(new SliderDto() { Id = sliderItem.Id, imageUrl = sliderItem.ImageUrl });
            }

            return sliderDto;
        }


        public List<FeaturedCategoryDto> getPublicMainView()
        {
            var featuredCategories = _unitOfWork.FeaturedCategoryRepository.GetAll();

            var subCategories = _unitOfWork.SubCategoryRepository.GetAll().Select(u=> new SubCategoryDto { 
                subCategoryId = u.Id , text = u.Title, featuredCategoryId = u.FeaturedCategoryId ,displayOrder = u.DisplayOrder ?? 0
            });

            List<FeaturedCategoryDto> featuredCategoryDto = new List<FeaturedCategoryDto>();

            foreach(var category in featuredCategories)
            {
                featuredCategoryDto.Add(new FeaturedCategoryDto()
                {
                    featuredCategoryId = category.Id,
                    imageURL   = category.ImageUrl,
                    text = category.Title,
                    displayOrder = category.DisplayOrder,
                    isPackage = category.IsPackage,
                    subCategory = subCategories.Where(u=>u.featuredCategoryId.Equals(category.Id)).ToList()
                });
            }

            return featuredCategoryDto;
        }

        //place-order
        public bool placeOrder(CreateOrderDto createOrderDto)
        {
            var allPricing = new List<int>();

            var products = _unitOfWork.ProductRepository.GetAllByIds(createOrderDto.products.Select(u => u.productId).ToList());
            var packages = _unitOfWork.PackageRepository.GetAllByIds(createOrderDto.packages.Select(u => u.packageId).ToList());
            
            allPricing.AddRange(products.Select(u => u.DeafultPriceId).ToList());
            

            foreach (var product in products)
            {
                allPricing.AddRange(product.PackageDetails.Select(u=>u.PriceId).ToList());
            }


            var pricing = _unitOfWork.PricingRepository.GetAllByIds(allPricing);

            Order order = new Order()
            {
                AdressId = createOrderDto.addressId,
                StatusId = (int)OrderStatusEnum.Active,
                IsActive = true,
                Total = 0,
                DiscountTotal = 0,
                TaxTotal = 0,
                CustomerId = 1,
                CreatedBy = 1,
                CreatedOn = DateTime.Now
            };
            _unitOfWork.OrderRepository.Add(order);

            List<OrderDetail> orderDetails = new List<OrderDetail>();
            foreach(var product in createOrderDto.products)
            {
                OrderDetail orderDetail = new OrderDetail()
                {
                    EntityId = product.productId,
                    EntityTypeId = 1,
                    IsActive = true,
                    OrderId = order.Id,
                    
                    PriceId = product.packingId == 0 ? 
                    products.FirstOrDefault(u=>u.Id == product.productId).DeafultPriceId : 
                    products.FirstOrDefault(u => u.Id == product.productId).ProductPackings.FirstOrDefault(u=>u.Id == product.packingId).PriceId,
                    PackingId = product.packingId,

                    TotalQty = product.qty,
                    CreatedBy = 1,
                    CreatedOn = DateTime.Now,
                    
                };

               orderDetails.Add(orderDetail);
            }

            //foreach (var product in createOrderDto.packages)
            //{
            //    OrderDetail orderDetail = new OrderDetail()
            //    {
            //        EntityId = product.packageId,
            //        EntityTypeId = 1,
            //        IsActive = true,
            //        OrderId = order.Id,

            //        PriceId = product.packingId == 0 ?
            //        products.FirstOrDefault(u => u.Id == product.productId).DeafultPriceId :
            //        products.FirstOrDefault(u => u.Id == product.productId).ProductPackings.FirstOrDefault(u => u.Id == product.packingId).PriceId,
            //        PackingId = 0,
            //        TotalQty = product.qty,
            //        CreatedBy = 1,
            //        CreatedOn = DateTime.Now,

            //    };

            //    orderDetails.Add(orderDetail);
            //}


            return true;
        }

        public bool addAddress(AddressDto addressDto)
        {
            Address addressObj = new Address()
            {
                LocationId = addressDto.locationId,
                IsActive = true,
                GeoLocaton = addressDto.googleLocation,
                AddressText = addressDto.addressText,
                CreatedBy = 1,
                CreatedOn = DateTime.Now
            };

            var address = _unitOfWork.AddressRepository.Add(addressObj);

            return true;
        }

        public bool deleteAddress(int id)
        {

            _unitOfWork.AddressRepository.DeleteAddress(id);

            return true;
        }
        public List<AddressDto> getAddress()
        {
            var locations = _unitOfWork.AddressRepository.GetAll();

            var locationDto = locations.Select(u => new AddressDto()
            {
                addressId = u.Id,
                googleLocation = u.GeoLocaton,
                locationText = u.Location.Title,
                addressText = u.AddressText,
                locationId = u.LocationId,
                isdefault = u.IsDefault

            }).ToList();


            return locationDto;
        }
        public bool addDefeaultAddress(int addressId)
        {
            try
            {
                var addresses = _unitOfWork.AddressRepository.GetAll();

                foreach (var address in addresses)
                {
                    address.IsDefault = false;
                }
                _unitOfWork.AddressRepository.UpdateList(addresses);

                var defaultAddress = _unitOfWork.AddressRepository.Get(addressId);

                defaultAddress.IsDefault = true;

                _unitOfWork.AddressRepository.UpdateAddress(defaultAddress);
            }
            catch (Exception ex)
            {

                return false;
            }

            return true;
        }
        public dynamic calculateOrderDetails(List<Product> products, List<Package> packages)
        {
            decimal total = 0;




            return new { };
        }
    }
}
