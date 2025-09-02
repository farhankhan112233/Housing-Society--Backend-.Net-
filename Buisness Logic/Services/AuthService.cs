using Housing_Society.Buisness_Logic.IServices;
using Housing_Society.Data_Access.IRespositories;
using Housing_Society.Models;
using Housing_Society.DTOs;


namespace Housing_Society.Buisness_Logic
{
    
    
    public class AuthService:IAuthService
    {
        private readonly IAuthRepository _authRepo;
        public AuthService(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        public async Task<SignupResponseDto?> Signup(SignupRequestDto signup)
        {
            if((signup.email == null || signup.password == null) && signup.name == null  )
            {
                return null;
            }
            var entity = new User
            {
                Name = signup.name,
                Email = signup.email ?? string.Empty,
                PasswordHash = signup.password?? string.Empty,
                Role = signup.role ?? string.Empty
            };
            var user =  await _authRepo.AddUser(entity);
            if(user is null)
            {
                return null;
            }
            return new SignupResponseDto {id= user.Id, name = user.Name, email = user.Email };
        }
        public async Task<LoginRequestDto?> Login(LoginRequestDto login)
        {
            if (login.username == null || login.password == null)
            {
                throw new Exception("Cannot be Null");
            }
            var entity = new User
            {
                Name = login.username,
                Email = login.email ?? string.Empty,
                PasswordHash = login.password,
                
            };
            var verify = await _authRepo.VerifyUser(entity);
            if(verify == null)
            {
                return null;
            }
            var response = new LoginRequestDto
            {
                id = login.id,
                username = login.username,
                password = login.password,

            };
            
            return response;
        }
    }
}
