using CloudCustomer.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CloudCustomer.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService userService;

    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpGet(Name = "GetUsers")]
    public async Task<IActionResult> Get()
    {
        var users = await this.userService.GetAllUsers();
        if (users.Any())
        {
            return Ok(users);
        }
        else 
        {
            return NotFound();
        }
        
    }
}
