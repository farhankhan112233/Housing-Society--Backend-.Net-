using Housing_Society.Buisness_Logic.IServices;
using Housing_Society.Data_Access.IRespositories;
using Housing_Society.DTOs;
using Housing_Society.Models;

namespace Housing_Society.Buisness_Logic
{
    
    
    public class AuthService:IAuthService
    {
        private readonly IAuthRepository _authRepo;
        public AuthService(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        public async Task<SignupResponseDto> Signup(SignupRequestDto signup)
        {
            if((signup.email == null || signup.password == null) && signup.name == null  )
            {
                throw new Exception();
            }
            var entity = new User
            {
                Name = signup.name,
                Email = signup.email ?? string.Empty,
                PasswordHash = signup.password?? string.Empty,
                Role = signup.role ?? string.Empty
            };
            var user =  await _authRepo.AddUser(entity);
            return new SignupResponseDto {id= user.Id, name = user.Name, email = user.Email };
        }
        public async Task<LoginResponsetDto?> Login(LoginRequestDto login)
        {
            if (login.username == null || login.password == null)
            {
                throw new Exception("Cannot be Null");
            }
            
            var response = await _authRepo.VerifyUser(login);
            if(response == null)
            {
                return null;
            }
            return new LoginResponsetDto { id = response.id, username = response.username };
        }
    }
}
