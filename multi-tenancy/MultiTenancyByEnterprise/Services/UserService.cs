using System.Security.Claims;

namespace MultiTenancyByEnterprise.Services
{
    public class UserService : IUserService
    {
        private readonly HttpContext httpContext;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContext = httpContextAccessor.HttpContext!;
        }

        public string GetUserId()
        {
            if (httpContext.User.Identity!.IsAuthenticated)
            {
                var claimId = httpContext.User.Claims
                    .Where(x => x.Type == ClaimTypes.NameIdentifier)
                    .FirstOrDefault();

                if (claimId == null)
                {
                    throw new ApplicationException("The user not have a claim");
                }

                return claimId!.Value;
            }
            else 
            {
                throw new ApplicationException("User not authenticated");
            }            
        }
    }
}
