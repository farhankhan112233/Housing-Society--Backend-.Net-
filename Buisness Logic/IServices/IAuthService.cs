using Housing_Society.DTOs;
using Housing_Society.Models;

namespace Housing_Society.Buisness_Logic.IServices
{
    public interface IAuthService
    {
        public Task<SignupResponseDto?> Signup(SignupRequestDto signup);
        public Task<LoginRequestDto> Login(LoginRequestDto login);
    }
}
