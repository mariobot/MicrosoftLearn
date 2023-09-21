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

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<VideoGame>> GetVideoGame(int id)
        {
            var game = await context.VideoGames.FindAsync(id);

            if (game == null)
            {
                return NotFound("This video game does not exist");
            }

            return Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult<VideoGame>> AddVideoGame(VideoGame videoGame)
        { 
            this.context.VideoGames.Add(videoGame);
            await context.SaveChangesAsync();

            return Ok(GetAllVideoGames());        
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<VideoGame>> UpdateVideoGame(int id, VideoGame videoGame)
        {
            var game = await context.VideoGames.FindAsync(id);

            if (game == null)
            {
                return NotFound("This video game does not exist");
            }

            game.Title = videoGame.Title;
            game.Publisher = videoGame.Publisher;
            game.ReleaseYear = videoGame.ReleaseYear;
            
            await context.SaveChangesAsync();

            return Ok(GetAllVideoGames());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<VideoGame>> DeleteVideoGame(int id)
        {
            var game = await context.VideoGames.FindAsync(id);

            if (game == null)
            {
                return NotFound("This video game does not exist");
            }

            context.VideoGames.Remove(game);
            await context.SaveChangesAsync();

            return Ok(GetAllVideoGames());
        }
    }
}
