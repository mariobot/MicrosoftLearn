using BlazorCrudDotNet8.Shared.Data;
using BlazorCrudDotNet8.Shared.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;

namespace BlazorCrudDotNet8.Shared.Services
{
    public class ClientGameService : IGameService
    {
        private readonly HttpClient httpClient;

        public ClientGameService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Game>> GetAllGames()
        {

            return null;
            //var result = await this.httpClient.GetAsync("/games");
            //return await result.Content.ReadFromJsonAsAsyncEnumerable<Game>();
        }

        public async Task<Game> GetGameById(int id) 
        {
            var result = await this.httpClient.GetFromJsonAsync<Game>($"/api/game/{id}");
            return result;
        }

        public async Task<Game> AddGame(Game game)
        {
            var result = await this.httpClient.PostAsJsonAsync<Game>("/api/game", game);
            return await result.Content.ReadFromJsonAsync<Game>();
        }
    }
}
