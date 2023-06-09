using System.Security.Claims;

namespace JwtWebApi.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        string IUserService.GetUsername()
        {
            var result = string.Empty;
            
            if (this.httpContextAccessor.HttpContext != null)
            {
                result = this.httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            }
            
            return result;
        }
    }
}
