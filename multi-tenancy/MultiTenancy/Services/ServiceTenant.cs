using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;

namespace MultiTenancy.Services
{
    public class ServiceTenant : IServiceTenant
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public ServiceTenant(IHttpContextAccessor httpContextAccessor) 
        { 
            this.httpContextAccessor = httpContextAccessor;
        }

        public string GetTenant()
        {
            var httpContext = httpContextAccessor.HttpContext;

            if (httpContext == null) 
            { 
                return string.Empty;
            }

            var authTicket = DecryptAuthCookie(httpContext);

            if (authTicket == null) 
            { 
                return string.Empty;
            }

            var claimTenant = authTicket.Principal.Claims.FirstOrDefault(x => x.Type == ConstantsProject.ClaimTenantId);

            if (claimTenant == null) 
            {
                return string.Empty;            
            }

            return claimTenant.Value;
            
        }

        private static AuthenticationTicket? DecryptAuthCookie(HttpContext httpContext)
        {
            var opt = httpContext.RequestServices
                .GetRequiredService<IOptionsMonitor<CookieAuthenticationOptions>>()
                .Get("Identity.Application");

            var cookie = opt.CookieManager.GetRequestCookie(httpContext, opt.Cookie.Name!);

            return opt.TicketDataFormat.Unprotect(cookie);
        }
    }
}
