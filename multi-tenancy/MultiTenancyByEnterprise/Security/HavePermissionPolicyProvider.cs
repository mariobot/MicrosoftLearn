using Microsoft.AspNetCore.Authorization;

namespace MultiTenancyByEnterprise.Security
{
    public class HavePermissionPolicyProvider : IAuthorizationPolicyProvider
    {
        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AuthorizationPolicy?> GetFallbackPolicyAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
        {
            throw new NotImplementedException();
        }
    }
}
