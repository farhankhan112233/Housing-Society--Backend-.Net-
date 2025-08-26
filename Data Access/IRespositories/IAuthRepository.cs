using Housing_Society.DTOs;
using Housing_Society.Models;

namespace Housing_Society.Data_Access.IRespositories
{
    public interface IAuthRepository
    {
        public Task<User> AddUser(User signup);
        public Task<LoginResponsetDto> VerifyUser(LoginRequestDto login);

    }
}
