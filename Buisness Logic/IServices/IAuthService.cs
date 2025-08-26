using Housing_Society.DTOs;

namespace Housing_Society.Buisness_Logic.IServices
{
    public interface IAuthService
    {
        public Task<SignupResponseDto> Signup(SignupRequestDto signup);
        public Task<LoginResponsetDto> Login(LoginRequestDto login);
    }
}
