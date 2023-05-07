
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
                return Unauthorized(new { responseMessage = "Please provide an id" });
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
        public IActionResult AddOrEditFeatCategory([FromBody]FeaturedCategoryDto featuredCategoryDto)
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
                return Unauthorized(new { responseMessage = "Please provide an id" });
            }
            else
            {
                var result = configurationService.DeleteFeaturedCategory(id);

                if (!result)
                    return Unauthorized(new { responseMessage = "Some thing went wrong." });

                return Ok(result);
            }
        }



    }

}