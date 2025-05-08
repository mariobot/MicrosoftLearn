using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyApi.Infraestructure;

namespace MyApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(UserManager<MyApplicationUser> userManager) : ControllerBase
{
    [HttpPost("Register")]
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

    [HttpGet("Test")]
    public async Task<ActionResult> Test()
    {
        return Ok();
    }
}

public record NewUser(string Username, string Password);
