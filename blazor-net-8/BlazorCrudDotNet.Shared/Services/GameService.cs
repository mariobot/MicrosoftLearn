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

        public async Task<Game> GetGameById(int id)
        { 
            var game = await this.dataContext.Games.FindAsync(id);
            if (game is not null)
            {
                return game;
            }

            throw new Exception("Game not found.");
        }

        public async Task<Game> EditGame(int id, Game game) 
        { 
            var gameToUpdate = await this.dataContext.Games.FindAsync(id);
            if (gameToUpdate is not null)
            {
                gameToUpdate.Name = game.Name;
                await this.dataContext.SaveChangesAsync();
                return gameToUpdate;
            }
            
            throw new Exception("Game not found,");
        
        }
        public async Task<bool> DeleteGame(int id)
        {
            var game = await this.dataContext.Games.FindAsync(id);
            if (game is not null)
            { 
                this.dataContext.Games.Remove(game);
                await this.dataContext.SaveChangesAsync();
                return true;            
            }
            return false;
        }
    }
}
