using Exam.BL;
using Exam.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalInfoController : ControllerBase
    {
        private readonly IPersonalInfoService _personalInfoService;
        public PersonalInfoController(IPersonalInfoService personalInfoService)
        {
            _personalInfoService = personalInfoService;
        }

        [HttpPut("UpdateFirstName")]
        [Authorize]
        public async Task UpdateFirstNameAsync(string firstName)
        {
            var id = int.Parse(User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value);
            await _personalInfoService.UpdateFirstNameAsync(firstName, id);
        }

        [HttpPut("UpdateLastName")]
        [Authorize]
        public async Task UpdateLastNameAsync(string lastName)
        {
            var id = int.Parse(User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value);
            await _personalInfoService.UpdateLastNameAsync(lastName, id);
        }

        [HttpPut("UpdatePersonalNumber")]
        [Authorize]
        public async Task UpdatePersonalNumberAsync(string personalNumber)
        {
            var id = int.Parse(User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value);
            await _personalInfoService.UpdatePersonalNumberAsync(personalNumber, id);
        }

        [HttpPut("UpdatePhoneNumber")]
        [Authorize]
        public async Task UpdatePhoneNumberAsync(string phoneNumber)
        {
            var id = int.Parse(User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value);
            await _personalInfoService.UpdatePhoneNumberAsync(phoneNumber, id);
        }

        [HttpPut("UpdateEmail")]
        [Authorize]
        public async Task UpdateEmailAsync(string email)
        {
            var id = int.Parse(User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value);
            await _personalInfoService.UpdateEmailAsync(email, id);
        }

        [HttpPut("UpdateImage")]
        [Authorize]
        public async Task UpdateImageAsync([FromForm] ImageUploadRequest request)
        {
            using var memoryStream = new MemoryStream();
            request.Image.CopyTo(memoryStream);
            var imageBytes = memoryStream.ToArray();
            var id = int.Parse(User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value);
            await _personalInfoService.UpdateImageAsync(imageBytes, id);
        }

    }




   
}
