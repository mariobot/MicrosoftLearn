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

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Game>> GetGameById(int id)
        { 
            var game = await this.gameService.GetGameById(id);
            return Ok(game);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Game>> EditGame(int id, Game game)
        {
            var gameToUpdate = await gameService.EditGame(id, game);
            return Ok(gameToUpdate);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        { 
            var result = await gameService.DeleteGame(id);
            return Ok(result);
        }
    }
}
