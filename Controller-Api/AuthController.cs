using Housing_Society.Buisness_Logic.IServices;
using Housing_Society.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Housing_Society.Controller_Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("signup")]
        public async Task<IActionResult> SaveInfo([FromBody] SignupRequestDto signup)
        {
            var createdUser = await _authService.Signup(signup);
                return Ok(createdUser);
        }
        [HttpPost("login")]
        public async Task<IActionResult> ValidateInfo([FromBody] LoginRequestDto login)
        {
            var verify = await _authService.Login(login);
            if(verify == null)
            {
                return BadRequest("Username Not Found");
            }
            return Ok(verify);
        }
    }
}
