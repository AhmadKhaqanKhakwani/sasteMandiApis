using BLL.Dtos.Mobile;
using BLL.Interfaces;
using Data.Context.UnitOfWork;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BLL.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConfigurationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public SliderResult GetAllSlider()
        {
            var slider = _unitOfWork.SliderRepository.GetAll().Where(s => s.IsActive == true).Select(u => new SliderDto { Id = u.Id, imageUrl = u.ImageUrl }).ToList();
            var result = new SliderResult();
            result.Sliders = slider;
            result.Total = slider.Count();
            return result;

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
                    sliderObj.UpdatedOn = DateTime.Now;
                    sliderObj.UpdatedBy = 1;



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
                isPackage = u.IsPackage,
                subCategory = u.SubCategories.Select(s => new SubCategoryDto
                {
                    featuredCategoryId = s.FeaturedCategoryId,
                    subCategoryId = s.Id,
                    title = s.Title,
                    CreatedBy = s.CreatedBy,
                    IsActive = s.IsActive,
                }).Where(u => u.IsActive).ToList()
            }).ToList();

            return data;


        }
        public bool AddOrEditFeaturedCategory(FeaturedCategoryDto featuredCategoryDto)
        {

            try
            {
                if (featuredCategoryDto.featuredCategoryId == 0)
                {
                    // Add Feat
                    var featureObj = new FeaturedCategory
                    {
                        Title = featuredCategoryDto.title,
                        IsPackage = true,
                        ImageUrl = featuredCategoryDto.imageURL,
                        Text = "..",
                        DisplayOrder = featuredCategoryDto.displayOrder,
                        IsActive = true,
                        CreatedBy = 1,
                        CreatedOn = System.DateTime.Now,
                    };

                    var featuredCategory = _unitOfWork.FeaturedCategoryRepository.Add(featureObj);

                    if (featuredCategory == null)
                    {
                        return false;
                    }
                    // Dynamically add
                    #region  //multiple
                    //foreach (var subCategoryDto in featuredCategoryDto.subCategory)
                    //{
                    //    var subCategory = new SubCategory
                    //    {

                    //        FeaturedCategoryId = featuredCategory.Id,
                    //        Title = subCategoryDto.text,
                    //        DisplayOrder = subCategoryDto.displayOrder,
                    //        IsActive = true,
                    //        CreatedBy = 786,
                    //        CreatedOn = System.DateTime.Now,
                    //    };

                    //};
                    #endregion

                    if (featuredCategoryDto.subCategory != null)
                    {
                        var subCategories = featuredCategoryDto.subCategory.Select(u => new SubCategory
                        {
                            FeaturedCategoryId = featuredCategory.Id,
                            Title = u.title,
                            DisplayOrder = 0,
                            IsActive = true,
                            CreatedBy = 1,
                            CreatedOn = System.DateTime.Now,
                        }).ToList();

                        var isListAdded =  _unitOfWork.SubCategoryRepository.AddRange(subCategories);
                        if (isListAdded is null)
                        {
                            return false;
                        }

                    }
                    return true;


                }
                else
                {
                    //update Feat
                    var currentFeaturedCategory = _unitOfWork.FeaturedCategoryRepository.Get(featuredCategoryDto.featuredCategoryId);
                    if (currentFeaturedCategory != null)
                    {
                        currentFeaturedCategory.ImageUrl = featuredCategoryDto.imageURL;
                        currentFeaturedCategory.Title = featuredCategoryDto.title;
                        currentFeaturedCategory.DisplayOrder = featuredCategoryDto.displayOrder;
                        currentFeaturedCategory.UpdatedOn = System.DateTime.Now;
                        currentFeaturedCategory.UpdatedBy = 1;

                        var updatedFeatured = _unitOfWork.FeaturedCategoryRepository.Update(currentFeaturedCategory);


                        var subCategoriesDb = _unitOfWork.SubCategoryRepository.GetByFeaturedId(featuredCategoryDto.featuredCategoryId).Select(u => u.Id).ToList();

                        // Retrieves the IDs of subcategories from the SubCategoryRepository for the specified featuredCategoryDto.featuredCategoryId and stores them in the subCategoriesDb list.
                        // Example: subCategoriesDb = [94, 95, 96]

                        var idsToDelete = subCategoriesDb.Where(u => !featuredCategoryDto.subCategory.Select(u => u.subCategoryId).ToList().Contains(u)).ToList();

                        // Compares the subcategories in subCategoriesDb with the subcategories in featuredCategoryDto.subCategory by their subCategoryId property.
                        // Retrieves the IDs from subCategoriesDb that are not present in featuredCategoryDto.subCategory and stores them in the idsToDelete list.
                        // Example: idsToDelete = [96]

                        if (featuredCategoryDto.subCategory != null)
                        {
                            foreach (var item in featuredCategoryDto.subCategory)
                            {
                                if (item.subCategoryId == 0)
                                {
                                    // Add
                                    var subCatObj = new SubCategory()
                                    {
                                        FeaturedCategoryId = currentFeaturedCategory.Id,
                                        Title = item.title,
                                        IsActive = true,
                                        DisplayOrder = item.displayOrder,
                                        CreatedOn = System.DateTime.Now,
                                        CreatedBy = 1,
                                    };
                                    var saved = _unitOfWork.SubCategoryRepository.Add(subCatObj);
                                    if (saved == null)
                                    {
                                        return false;
                                    }
                                }
                                else
                                {

                                    // update
                                    var currentSubCat = _unitOfWork.SubCategoryRepository.Get(item.subCategoryId);

                                    if (currentSubCat != null)
                                    {
                                        //currentSubCat.FeaturedCategoryId = item.featuredCategoryId;
                                        //currentSubCat.Id = item.subCategoryId;
                                        currentSubCat.Title = item.title;
                                        currentSubCat.IsActive = item.IsActive;
                                        currentSubCat.DisplayOrder = 0;
                                        currentSubCat.UpdatedOn = DateTime.Now;
                                        currentSubCat.UpdatedBy = 1;

                                        var updatedSubCat = _unitOfWork.SubCategoryRepository.Update(currentSubCat);
                                        if (updatedSubCat == null)
                                        {
                                            return false;
                                        }
                                    }

                                }
                            }
                        }


                        if (idsToDelete != null && idsToDelete.Any())
                        {
                            foreach (var item in idsToDelete)
                            {
                                var isDeleted =  _unitOfWork.SubCategoryRepository.Delete(item);
                                if (!isDeleted)
                                {
                                    return false;
                                }
                            }
                        }
                        return true;
                    }
                    else return false;



                }

            }
            catch (System.Exception ex)
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


        //Location Work

        public List<LocationDto> GetAllLocation()
        {
            var result = _unitOfWork.LocationRepository.GetAll().Where(l => l.IsActive == true)
                .Select(loc => new LocationDto
                {
                    id = loc.Id,
                    title = loc.Title,
                }).ToList();
            return result;
        }

        public LocationDto GetLocation(int id)
        {
            var result = _unitOfWork.LocationRepository.Get(id);
            if (result != null)
            {
                var obj = new LocationDto { id = result.Id, title = result.Title };
                return obj;
            }
            return null;
        }

        public bool AddOrUpdateLocation(LocationDto locationDto)
        {
            // add loc
            if (locationDto.id == 0)
            {
                var newLocation = new Location
                {
                    Title = locationDto.title,
                    IsActive = true,
                    CreatedOn = DateTime.Now,
                    CreatedBy = 1,
                };
                var isSaved = _unitOfWork.LocationRepository.Add(newLocation);
                return isSaved != null;

            }
            else
            {
                //update
                var locationObj = _unitOfWork.LocationRepository.Get(locationDto.id);
                locationObj.Title = locationDto.title;
                locationObj.UpdatedOn = DateTime.Now;
                locationObj.UpdatedBy = 1;

               var isUpdated =  _unitOfWork.LocationRepository.Update(locationObj);

                return isUpdated != null;
            }

        }

        public bool DeleteLocation(int id)
        {
            var result = _unitOfWork.LocationRepository.Delete(id);
            return result;
        }


    }
}
