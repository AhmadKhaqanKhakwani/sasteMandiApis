﻿using BLL.Dtos.Mobile;
using BLL.Interfaces;
using Data.Context.UnitOfWork;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConfigurationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<SliderDto> GetAllSlider()
        {
            var slider = _unitOfWork.SliderRepository.GetAll().Select(u => new SliderDto { Id = u.Id, imageUrl = u.ImageUrl }).ToList();
            return slider;

        }

        public bool AddOrUpdateSlider(SliderDto sliderDto)
        {
            try
            {
                if (sliderDto.Id > 0)
                {
                    //update
                    var sliderObj = _unitOfWork.SliderRepository.Get(sliderDto.Id);
                    sliderObj.ImageUrl = sliderDto.imageUrl;


                    _unitOfWork.SliderRepository.UpdateSlider(sliderObj);
                }
                else
                {
                    // Add
                    var sliderObj = new Slider
                    {
                        ImageUrl = sliderDto.imageUrl,
                        IsActive = true,
                        PackageId = 0,
                        Task = string.Empty,
                        CreatedBy = 1,
                        CreatedOn = System.DateTime.Now
                    };

                    _unitOfWork.SliderRepository.Add(sliderObj);
                }


                return true;
            }
            catch (System.Exception)
            {

                return false;
            }

        }

        public bool DeleteSlider(int id)
        {
            var result = _unitOfWork.SliderRepository.DeleteSlider(id);
            return result;
        }

        // FeaturedCategories Work
        public List<FeaturedCategoryDto> GetAllFeaturedCategory()
        {
            var data = _unitOfWork.FeaturedCategoryRepository.GetAll().Select(u => new FeaturedCategoryDto
            {
                featuredCategoryId = u.Id,
                title = u.Title,
                imageURL = u.ImageUrl,
                displayOrder = u.DisplayOrder,
                text = u.Text,
                IsActive = u.IsActive,
                subCategory = u.SubCategories.Select(s => new SubCategoryDto
                {
                    featuredCategoryId = s.FeaturedCategoryId,
                    subCategoryId = s.Id,
                    text = s.Title,
                    //displayOrder = s.DisplayOrder,
                    CreatedBy = s.CreatedBy,
                    IsActive = s.IsActive,
                }).ToList()
            }).ToList();

            return data;


        }
        public bool Savefeaturedcategories(FeaturedCategoryDto featuredCategoryDto)
        {
            return true;
        }
        public bool AddOrEditFeaturedCategory(FeaturedCategoryDto featuredCategoryDto)
        {

            try
            {
                if (featuredCategoryDto.featuredCategoryId > 0)
                {
                    //update
                    var currentFeaturedCategory = _unitOfWork.FeaturedCategoryRepository.Get(featuredCategoryDto.featuredCategoryId);
                    if (currentFeaturedCategory != null)
                    {
                        currentFeaturedCategory.ImageUrl = featuredCategoryDto.imageURL;
                        currentFeaturedCategory.DisplayOrder = featuredCategoryDto.displayOrder;
                        currentFeaturedCategory.UpdatedOn = System.DateTime.Now;
                        currentFeaturedCategory.UpdatedBy = 1;

                        // subCategories
                        //var subCategoryList = featuredCategoryDto.subCategory;
                        //var subCatObj = new SubCategory()
                        //{
                        //    Title = featuredCategoryDto.text,
                        //    IsActive = true,
                        //    DisplayOrder = featuredCategoryDto.displayOrder,
                        //    CreatedOn = System.DateTime.Now,
                        //    CreatedBy = 1
                        //};
                    }


                    _unitOfWork.FeaturedCategoryRepository.Update(currentFeaturedCategory);
                }
                else
                {

                    
                    // Add
                    var featureObj = new FeaturedCategory
                    {
                        Title = featuredCategoryDto.title,
                        IsPackage = true,
                        ImageUrl = featuredCategoryDto.imageURL,
                        Text = featuredCategoryDto.text,
                        DisplayOrder = featuredCategoryDto.displayOrder,
                        IsActive = true,
                        CreatedBy = 1,
                        CreatedOn = System.DateTime.Now,
                    };

                    // Dynamically add
                    foreach (var subCategoryDto in featuredCategoryDto.subCategory)
                    {
                        var subCategory = new SubCategory
                        {
                            FeaturedCategoryId = subCategoryDto.featuredCategoryId,
                            Title = subCategoryDto.text,
                            DisplayOrder = subCategoryDto.displayOrder,
                            IsActive = true,
                            CreatedBy = 786,
                            CreatedOn = System.DateTime.Now,
                        };

                        _unitOfWork.SubCategoryRepository.Add(subCategory);
                    };

                    _unitOfWork.FeaturedCategoryRepository.Add(featureObj);
                }


                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public bool DeleteFeaturedCategory(int id)
        {
            try
            {
                var result = _unitOfWork.FeaturedCategoryRepository.DeleteFeaturedCategory(id);
                return result;

            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
