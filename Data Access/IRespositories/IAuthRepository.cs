using Housing_Society.Models;
using Housing_Society.DTOs;

namespace Housing_Society.Data_Access.IRespositories
{
    public interface IAuthRepository
    {
        public Task<User> AddUser(User signup);
        public Task<User> VerifyUser(User login);

    }
}
