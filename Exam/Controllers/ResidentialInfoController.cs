using Exam.BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResidentialInfoController : ControllerBase
    {
        private readonly IResidentialInfoService _residentialInfoService;
        public ResidentialInfoController(IResidentialInfoService residentialInfoService)
        {
            _residentialInfoService = residentialInfoService;
        }

        [HttpPut("UpdateCity")]
        [Authorize]
        public async Task UpdateCityAsync(string city)
        {
            var id = int.Parse(User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value);
            await _residentialInfoService.UpdateCityAsync(city, id);
        }

        [HttpPut("UpdateStreet")]
        [Authorize]
        public async Task UpdateStreetAsync(string streetName)
        {
            var id = int.Parse(User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value);
            await _residentialInfoService.UpdateStreetNameAsync(streetName, id);
        }

        [HttpPut("UpdateHouseNumber")]
        [Authorize]
        public async Task UpdateHouseNumberAsync(string houseNumber)
        {
            var id = int.Parse(User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value);
            await _residentialInfoService.UpdateHouseNumberAsync(houseNumber, id);
        }

        [HttpPut("UpdateApartmentNumber")]
        [Authorize]
        public async Task UpdateApartmentNumberAsync(string apartmentNumber)
        {
            var id = int.Parse(User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value);
            await _residentialInfoService.UpdateApartmentNumberAsync(apartmentNumber, id);
        }

    }
}
