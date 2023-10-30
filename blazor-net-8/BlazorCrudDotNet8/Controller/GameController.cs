using BlazorCrudDotNet8.Shared.Entity;
using BlazorCrudDotNet8.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCrudDotNet8.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService gameService;

        public GameController(IGameService gameService)
        {
            this.gameService = gameService;
        }

        [HttpPost]
        public async Task<ActionResult<Game>> AddGame(Game game)
        { 
            var addGame = await this.gameService.AddGame(game);
            return Ok(addGame);
        }
    }
}
