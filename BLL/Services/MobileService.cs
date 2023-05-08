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

        public List<PublicProductDto> getProducts()
        {
            var products = _unitOfWork.ProductRepository.GetAll();
           

            var productDtos = new List<PublicProductDto>();
            foreach(var product in products)
            {
                productDtos.Add(new PublicProductDto()
                {
                    textEng = product.TitleEng,
                    textUrdu = product.TitleUrdu,
                    imageUrl = product.ProductImages.FirstOrDefault()?.ImageUrl ?? "",
                    displayOrder = 1,
                    packaging = product.ProductPackings.Select(u=>new Packaging() { text = u.Weight.ToString() , price = 100 , oldPrice = 50, isDeafult = u.IsDefault}).ToList() ,
                    categoryId = product.FeaturedCategoryId,
                    subCategory = product.SubCategoryToProducts.Select(u=>u.Id).ToList()
                });
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
                {
                    title = package.PackageTitle,
                    totalPrice = package.PackageTotalPrice,
                    products = products.Where(u => package.PackageDetails.Select(u => u.ProductId).ToList().Contains(u.Id)).Select(u => new PublicProductDto().toPackageProductDTO(u)).ToList()
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
                    text = category.Text,
                    displayOrder = category.DisplayOrder,
                    subCategory = subCategories.Where(u=>u.featuredCategoryId.Equals(category.Id)).ToList()
                });
            }

            return featuredCategoryDto;
        }

        //placeorder
        public bool placeOrder(CreateOrderDto createOrderDto)
        {
            var products = _unitOfWork.ProductRepository.GetAllByIds(createOrderDto.products.Select(u => u.productId).ToList());
            // var packages = _unitOfWork.PackageRepository.ge


            Order order = new Order()
            {
                AdressId = createOrderDto.address.addressId,
                StatusId = (int)OrderStatusEnum.Active,
                IsActive = true,
                Total = 0,
                DiscountTotal = 0,
                TaxTotal = 0,
                CreatedBy = 1,
                CreatedOn = DateTime.Now
            };
            _unitOfWork.OrderRepository.Add(order);

            return true;
        }

        public bool addAddress(AddressDto addressDto)
        {
            Address address = new Address()
            {
                LocationId = addressDto.locationId,
                IsActive = true,
                GeoLocaton = addressDto.googleLocation,
                AddressText = addressDto.addressText,
                CreatedBy = 1,
                CreatedOn = DateTime.Now
            };

            var addresss = _unitOfWork.AddressRepository.Add(address);

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
                locationId = u.LocationId
            }).ToList();


            return locationDto;
        }
        public dynamic calculateOrderDetails(List<Product> products, List<Package> packages)
        {
            decimal total = 0;




            return new { };
        }
    }
}
