using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyApi.Infraestructure;

namespace MyApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(UserManager<MyApplicationUser> userManager, IConfiguration configuration) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] NewUser user)
    {
        var myApplicationUser = new MyApplicationUser
        {
            UserName = user.Username,
            Email = user.Username,
        };

        var result = await userManager.CreateAsync(myApplicationUser, user.Password);

        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUser user)
    {
        var currentUser = await userManager.FindByNameAsync(user.Username);
        if (currentUser == null || !await userManager.CheckPasswordAsync(currentUser, user.Password))
        {
            return Unauthorized();
        }

        var token = GenerateToken(currentUser);

        return Ok(token);
    }

    private string GenerateToken(MyApplicationUser user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.NameId, user.UserName),
            new Claim(ClaimTypes.NameIdentifier, user.UserName)
        };

        var keyBytes = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
        var key = new SymmetricSecurityKey(keyBytes);
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expiration = DateTime.Now.AddHours(2);

        var token = new JwtSecurityToken("MyApi", "MyCompany", claims, null, expiration, creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    [HttpGet("test")]
    public async Task<ActionResult> Test()
    {
        return Ok();
    }
}

public record NewUser(string Username, string Password);
public record LoginUser(string Username, string Password);
