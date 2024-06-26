﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("login")]
        public async Task<ActionResult> Login(UserLoginRequest userLoginRequest)
        {
            var user = await this.dataContext.Users.FirstOrDefaultAsync(x => x.Email == userLoginRequest.Email);

            if (user == null) 
            {
                return BadRequest("User not found");
            }

            if (!VerifyPasswordHash(userLoginRequest.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Password is incorrect.");
            }

            if (user.VerifiedAt == null)
            {
                return BadRequest("Not verified!");
            }

            return Ok($"Welcome back, {user.Email}!");
        }

        [HttpPost("verify")]
        public async Task<ActionResult> Verify(string token)
        {
            var user = await this.dataContext.Users.FirstOrDefaultAsync(x => x.VerificationToken == token);

            if (user == null)
            {
                return BadRequest("Invalid token.");
            }

            user.VerifiedAt = DateTime.UtcNow;
            await this.dataContext.SaveChangesAsync();

            return Ok($"User verified!");
        }

        [HttpPost("forogot-password")]
        public async Task<ActionResult> ForgotPassword(string email)
        {
            var user = await this.dataContext.Users.FirstOrDefaultAsync(x => x.Email == email);

            if (user == null)
            {
                return BadRequest("User not found.");
            }
            
            user.PasswordResetToken = CreateRandomToken();
            user.ResetTokenExpires = DateTime.UtcNow.AddDays(1);
            await this.dataContext.SaveChangesAsync();

            return Ok($"You may now reset your password!");
        }

        [HttpPost("reset-password")]
        public async Task<ActionResult> ResetPassword(ResetPasswordRequest resetPasswordRequest)
        {
            var user = await this.dataContext.Users.FirstOrDefaultAsync(x => x.PasswordResetToken == resetPasswordRequest.Token);

            if (user == null || user.ResetTokenExpires < DateTime.Now)
            {
                return BadRequest("Invalid Token.");
            }

            CreatePasswordHash(resetPasswordRequest.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.PasswordResetToken = null;
            user.ResetTokenExpires = null;
            await this.dataContext.SaveChangesAsync();

            return Ok($"Password successfully reset.");
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }        
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));        
        }
    }
}
