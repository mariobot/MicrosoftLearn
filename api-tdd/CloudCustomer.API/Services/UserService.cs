using CloudCustomer.API.Models;

namespace CloudCustomer.API.Services
{
    public interface IUserService {
        public Task<List<User>> GetAllUsers();
    }
    public class UserService : IUserService
    {
        private readonly HttpClient httpClient;

        public UserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await this.httpClient.GetAsync("https://example.com");
            return new List<User> { };
        }
    }
}
