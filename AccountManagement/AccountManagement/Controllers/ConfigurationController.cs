
using BLL.Dtos.Mobile;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace SasteMandi.Controllers
{
    [Produces("application/json")]
    [Route("api/configuration")]
    public class ConfigurationController : Controller
    {
        private IConfiguration configuration;
        private IConfigurationService configurationService;

        public ConfigurationController(IConfiguration _configuration, IConfigurationService _configurationService)
        {
            configuration = _configuration;
            configurationService = _configurationService;
        }

        #region ConfigurationModule

        // slider  APIs
        [AllowAnonymous]
        [HttpGet]
        [ActionName("GetAllSlider")]
        [Route("GetAllSlider")]
        public IActionResult GetAllSlider()
        {

            var result = configurationService.GetAllSlider();

            if (result == null)
                return Unauthorized(new { responseMessage = "Some thing went wrong." });

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost]
        [ActionName("AddOrUpdateSlider")]
        [Route("AddOrUpdateSlider")]
        public IActionResult AddOrUpdateSlider([FromBody] SliderDto slider)
        {
            if (slider == null || slider.imageUrl.Trim() == "")
            {
                return Ok("Please provide valid payload");
            }
            var result = configurationService.AddOrUpdateSlider(slider);

            if (!result)
                return Unauthorized(new { responseMessage = "Some thing went wrong." });

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpDelete]
        [ActionName("DeleteSlider")]
        [Route("DeleteSlider")]
        public IActionResult DeleteSlider([FromBody] int id)
        {
            if (id == 0)
            {
                return Unauthorized(new { responseMessage = "Invalid payload!" });
            }
            else
            {
                var result = configurationService.DeleteSlider(id);

                if (!result)
                    return Unauthorized(new { responseMessage = "Some thing went wrong." });

                return Ok(result);
            }
        }

        // FeaturedCategory APIs

        [AllowAnonymous]
        [HttpGet]
        [ActionName("GetAllFeaturedCategory")]
        [Route("GetAllFeaturedCategory")]
        public IActionResult GetAllFeaturedCategory()
        {

            var result = configurationService.GetAllFeaturedCategory();

            if (result == null)
                return Unauthorized(new { responseMessage = "Some thing went wrong." });

            return Ok(result);
        }
        [AllowAnonymous]
        [HttpPost]
        [ActionName("AddOrEditFeatCategory")]
        [Route("AddOrEditFeatCategory")]
        public IActionResult AddOrEditFeatCategory([FromBody] FeaturedCategoryDto featuredCategoryDto)
        {

            var result = configurationService.AddOrEditFeaturedCategory(featuredCategoryDto);

            if (!result)
                return Unauthorized(new { responseMessage = "Some thing went wrong." });

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpDelete]
        [ActionName("DeleteFeaturedCategory")]
        [Route("DeleteFeaturedCategory")]
        public IActionResult DeleteFeaturedCategory([FromBody] int id)
        {
            if (id == 0)
            {
                return Unauthorized(new { responseMessage = "Invalid payload!" });
            }
            else
            {
                var result = configurationService.DeleteFeaturedCategory(id);

                if (!result)
                    return Unauthorized(new { responseMessage = "Some thing went wrong." });

                return Ok(result);
            }
        }

        // Location  APIs

        [AllowAnonymous]
        [HttpGet]
        [ActionName("GetAllLocation")]
        [Route("GetAllLocation")]
        public IActionResult GetAllLocation()
        {
            var records = configurationService.GetAllLocation();
            if (records == null)
                return Ok(new { responseMessage = "No data found" });

            return Ok(records);
        }


        [AllowAnonymous]
        [HttpGet]
        [ActionName("GetLocation")]
        [Route("GetLocation")]
        public IActionResult GetLocation([FromBody] int id)
        {
            if (id == 0)
            {
                return Ok(new { responseMessage = "Please provide an id" });
            }
            var records = configurationService.GetLocation(id);
            if (records == null)
                return Ok(new { responseMessage = "No data found" });

            return Ok(records);
        }

        [AllowAnonymous]
        [HttpPost]
        [ActionName("AddOrUpdateLocation")]
        [Route("AddOrUpdateLocation")]
        public IActionResult AddOrUpdateLocation([FromBody] LocationDto locationDto)
        {

            var result = configurationService.AddOrUpdateLocation(locationDto);

            if (!result)
                return Unauthorized(new { responseMessage = "Some thing went wrong." });

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpDelete]
        [ActionName("DeleteLocation")]
        [Route("DeleteLocation")]
        public IActionResult DeleteLocation([FromBody] int id)
        {
            if (id == 0)
            {
                return Unauthorized(new { responseMessage = "Please provide an id" });
            }
            else
            {
                var result = configurationService.DeleteLocation(id);

                if (!result)
                    return Unauthorized(new { responseMessage = "Some thing went wrong." });

                return Ok(result);
            }
        }
        #endregion

        #region ProductModule

        [AllowAnonymous]
        [HttpPost]
        [ActionName("AddProduct")]
        [Route("AddProduct")]
        public IActionResult AddProduct([FromBody] AddProductDto addProductDto)
        {
            if (addProductDto is null)
            {
                return Ok("Please provide valid payload");
            }
            var result = configurationService.AddProduct(addProductDto);

            if (!result)
                return Unauthorized(new { responseMessage = "Some thing went wrong." });

            return Ok(result);
        }
        #endregion




    }

}