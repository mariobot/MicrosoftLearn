using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using VarifyEmail.Data;

namespace VarifyEmail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext dataContext;

        public UserController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserRegisterRequest userRegisterRequest)
        { 

            if (this.dataContext.Users.Any(x => x.Email == userRegisterRequest.Email)) 
            {
                return BadRequest("Use already exists.");            
            }

            CreatePasswordHash(userRegisterRequest.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User
            {
                Email = userRegisterRequest.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                VerificationToken = CreateRandomToken()
            };

            this.dataContext.Users.Add(user);
            await this.dataContext.SaveChangesAsync();

            return Ok("User successfully created!");
        
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }        
        }

        private string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));        
        }
    }
}
