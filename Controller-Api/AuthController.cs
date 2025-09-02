using Housing_Society.Buisness_Logic.IServices;
using Housing_Society.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Housing_Society.Controller_Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ITokenService _token;
        public AuthController(IAuthService authService, ITokenService token)
        {
            _authService = authService;
            _token = token;
        }
        
        [HttpPost("signup")]
        public async Task<IActionResult> SaveInfo([FromBody] SignupRequestDto dto)
        {
            var createdUser = await _authService.Signup(dto);
            if(createdUser == null)
            {
                return StatusCode(400, "Data Already Exists")
;            }
                return Ok(createdUser);
        }
        [HttpPost("login")]
        public async Task<IActionResult> ValidateInfo([FromBody] LoginRequestDto dto)
        {
            var verifiedUser = await _authService.Login(dto);
            
            if(verifiedUser == null)
            {
                return BadRequest("Username Not Found");
            }
            var token = await _token.GenerateToken(verifiedUser);

            return Ok(new { Token = token});           
        }
    }
}
