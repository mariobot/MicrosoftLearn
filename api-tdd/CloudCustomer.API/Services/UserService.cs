using CloudCustomer.API.Config;
using CloudCustomer.API.Models;
using Microsoft.Extensions.Options;

namespace CloudCustomer.API.Services
{
    public interface IUserService {
        public Task<List<User>> GetAllUsers();
    }
    public class UserService : IUserService
    {
        private readonly HttpClient httpClient;
        private readonly UsersApiOptions apiConfig;

        public UserService(HttpClient httpClient, IOptions<UsersApiOptions> apiConfig)
        {
            this.httpClient = httpClient;
            this.apiConfig = apiConfig.Value;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await this.httpClient.GetAsync(this.apiConfig.Endpoint);
            if (users.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new List<User> { };
            }
            var responseContent = users.Content;
            var allUsers = await responseContent.ReadFromJsonAsync<List<User>>();
            return allUsers.ToList();
        }
    }
}
