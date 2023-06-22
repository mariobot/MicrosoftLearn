using Microsoft.AspNetCore.Mvc;

namespace VarifyEmail.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {                
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {   
        }
    }
}