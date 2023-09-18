using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleVideoGameLibrary.Server.Data;
using SimpleVideoGameLibrary.Shared;

namespace SimpleVideoGameLibrary.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {   
        private readonly DataContext context;

        public VideoGameController(DataContext context)
        {
            this.context = context;
        }

        public async Task<ActionResult<List<VideoGame>>> GetAllVideoGames() 
        {
            var list = await context.VideoGames.OrderBy(x => x.ReleaseYear).ToListAsync();

            return Ok(list);        
        }
    }
}
