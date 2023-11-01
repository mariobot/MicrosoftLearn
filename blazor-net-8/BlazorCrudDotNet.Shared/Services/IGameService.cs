using BlazorCrudDotNet8.Shared.Entity;

namespace BlazorCrudDotNet8.Shared.Services
{
    public interface IGameService
    {
        Task<List<Game>> GetAllGames();
        Task<Game> AddGame(Game game);
        Task<Game> GetGameById(int id);
        Task<Game> EditGame(int id, Game game);
        Task<bool> DeleteGame(int id);
    }
}
