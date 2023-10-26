using BlazorCrudDotNet8.Entity;

namespace BlazorCrudDotNet8.Services
{
    public interface IGameService
    {
        Task<List<Game>> GetAllGames();
    }
}
