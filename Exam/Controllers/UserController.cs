using Exam.BL;
using Exam.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UserController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public UserController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet("GetUser")]
        [Authorize]
        public async Task<UserAccount> GetUserAccountAsync()
        {
            var id = int.Parse(User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value);

            return await _usersService.GetUserAccountAsync(id);
        }
        [HttpDelete("Delete")]
        [Authorize(Roles = "Admin")]
        public async Task DeleteUserAccountAsync(int id)
        {
            await _usersService.DeleteUserAccountAsync(id);
        }
        
    }
}
