using BlazorCrudDotNet8.Data;
using BlazorCrudDotNet8.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrudDotNet8.Services
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
    }
}
