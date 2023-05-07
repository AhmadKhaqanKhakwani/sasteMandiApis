
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using SasteMandi.Common;
using BLL.Dtos;
using BLL.Services;
using BLL.Interfaces;
using Data.Entities;
using BLL.Dtos.Mobile;

namespace SasteMandi.Controllers
{
    [Produces("application/json")]
    [Route("api/mobile")]
    public class MobileController : Controller
    {
        private IConfiguration configuration;
        private IMobileService _mobileService;

        public MobileController(IConfiguration _configuration, IMobileService mobileService)
        {
            configuration = _configuration;
            _mobileService = mobileService;
        }

        [AllowAnonymous]
        [HttpGet]
        [ActionName("getDashboardCategories")]
        [Route("getDashboardCategories")]
        public IActionResult getDashboardCategories()
        {

            var result = _mobileService.getPublicMainView();

            if (result == null)
                return Unauthorized(new { responseMessage = "Some thing went wrong." });

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet]
        [ActionName("getDashboardSlider")]
        [Route("getDashboardSlider")]
        public IActionResult getDashboardSlider()
        {

            var result = _mobileService.getSlider();

            if (result == null)
                return Unauthorized(new { responseMessage = "Some thing went wrong." });

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet]
        [ActionName("getDashboardProduct")]
        [Route("getDashboardProduct")]
        public IActionResult getDashboardProduct()
        {

            var result = _mobileService.getProducts();

            if (result == null)
                return Unauthorized(new { responseMessage = "Some thing went wrong." });

            return Ok(result);
        }


        [AllowAnonymous]
        [HttpGet]
        [ActionName("getDashboardPackages")]
        [Route("getDashboardPackages")]
        public IActionResult getDashboardPackages()
        {

            var result = _mobileService.getPackages();

            if (result == null)
                return Unauthorized(new { responseMessage = "Some thing went wrong." });

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet]
        [ActionName("getLocations")]
        [Route("getLocations")]
        public IActionResult getLocations()
        {

            var result = _mobileService.getLocations();

            if (result == null)
                return Unauthorized(new { responseMessage = "Some thing went wrong." });

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost]
        [ActionName("placeOrder")]
        [Route("placeOrder")]
        public IActionResult placeOrder([FromBody]CreateOrderDto createOrderDto)
        {
            if(createOrderDto == null || createOrderDto.locationId == 0)
                return Unauthorized(new { responseMessage = "Payload is incorrect" });


            return Ok(new { responseMessage = "Success." });
        }

    }

}