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
                    categoryId = product.CategoryId,
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
    }
}
