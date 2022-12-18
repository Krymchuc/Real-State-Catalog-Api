using Real_State_Catalog.Shared.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;


namespace Real_State_Catalog_API.Controllers
{


    [Route("api/[controller]")]
    public class AmenityController : Controller
    {
        private readonly IAmenityRepository _hotelAmenityRepository;

        //Access IHotelAmenityRepo so we can access the HotelAmenityRepo methods like GetAllHotelAmenity

        public AmenityController( IAmenityRepository hotelAmenityRepository)
        {
        _hotelAmenityRepository = hotelAmenityRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAmenityList()
        {
            //Simple method of retrieving all amenities from db using the GetAllHotelAmenity method
            var amenityList = await _hotelAmenityRepository.GetAllAmenity();
            return Ok(amenityList);
    
        } 
    }
}
