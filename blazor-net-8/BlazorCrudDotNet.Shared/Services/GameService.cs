using BlazorCrudDotNet8.Shared.Data;
using BlazorCrudDotNet8.Shared.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrudDotNet8.Shared.Services
{
    public class GameService : IGameService
    {
        private readonly DataContext dataContext;

        public GameService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<List<Game>> GetAllGames() 
        {
            var games = await this.dataContext.Games.ToListAsync();
            return games;
        }

        public async Task<Game> AddGame(Game game)
        { 
            this.dataContext.Games.Add(game);
            await this.dataContext.SaveChangesAsync();

            return game;
        }
    }
}
