using Housing_Society.Data_Access.IRespositories;
using Housing_Society.DTOs;
using Housing_Society.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Housing_Society.Data_Access
{
    public class AuthRepository : IAuthRepository
    {
        private readonly HousingSocietyContext dbContext;
        public AuthRepository(HousingSocietyContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<User?> AddUser(User signup)
        {
            var exUser =await  dbContext.Users
                              .FirstOrDefaultAsync(x => x.Email == signup.Email
                              || x.Name == signup.Name);
            if(exUser is not null )
            {
                return null; ;
            }
            await dbContext.Users.AddAsync(signup);
            await dbContext.SaveChangesAsync();
            return signup;
        }
        public async Task<User> VerifyUser(User login)
        {
            var exUser = await dbContext.Users
                .FirstOrDefaultAsync
                (x => x.Name == login.Name && 
                x.PasswordHash == login.PasswordHash);
            if(exUser is null)
            {
                return null;
            }
            return exUser;
        }
    }
}
