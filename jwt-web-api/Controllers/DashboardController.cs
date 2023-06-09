using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public ActionResult GetDashboard() 
        {
            return Ok("Dashboard page");        
        }
    }
}
