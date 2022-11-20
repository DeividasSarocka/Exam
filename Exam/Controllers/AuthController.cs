using Exam.BL;
using Exam.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserAccountsService _userAccountsService;
        private readonly IJwtService _jwtService;
        public AuthController(IUserAccountsService userAccountsService, IJwtService jwtService)                                                     
        {
            _userAccountsService = userAccountsService;
            _jwtService = jwtService;
        }
        [HttpPost("Signup")]
        public async Task<IActionResult> Signup([FromQuery] SignupDto signupDto, [FromForm] ImageUploadRequest request) 
        {
            using var memoryStream = new MemoryStream();
            request.Image.CopyTo(memoryStream);
            var imageBytes = memoryStream.ToArray();
            var success = await _userAccountsService.CreateUserAccountAsync(signupDto, imageBytes);
            return success ? Ok() : BadRequest(new { ErrorMessage = "User already exist" });
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var (loginSuccess, account) = await _userAccountsService.LoginAsync(loginDto.UserName, loginDto.Password);

            if (loginSuccess)
            {
                return Ok(_jwtService.GetJwtToken(account));
            }
            else
            {
                return BadRequest(new { ErrorMessage = "Login failed" });
            }

        }

        //[HttpPost("Upload")]                        //TRINTI JUODRASTIS
        //public ActionResult UploadImage([FromForm]ImageUploadRequest request)
        //{
        //    using var memoryStream = new MemoryStream();
        //    request.Image.CopyTo(memoryStream);
        //    var imageBytes = memoryStream.ToArray();
        //    //TODO: Save image to database
        //    return Ok();
        //}

    }
}
