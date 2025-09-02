using Housing_Society.DTOs;
using Housing_Society.Models;

namespace Housing_Society.Buisness_Logic.IServices
{
    public interface ITokenService
    {
        Task<string> GenerateToken(LoginRequestDto user);
    }
}
