using Microsoft.AspNetCore.Authorization;
using MultiTenancyByEnterprise.Entities;
using MultiTenancyByEnterprise.Services;
using System.Security.Cryptography;

namespace MultiTenancyByEnterprise.Security
{
    public class HavePermissionPolicyProvider : IAuthorizationPolicyProvider
    {
        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
            return Task.FromResult(new AuthorizationPolicyBuilder("Identity.Application")
                .RequireAuthenticatedUser().Build());            
        }

        public Task<AuthorizationPolicy?> GetFallbackPolicyAsync()
        {
            return Task.FromResult<AuthorizationPolicy?>(null!);
        }

        public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
        {
            if (policyName.StartsWith(ConstantsProject.PrefixPolicy, StringComparison.OrdinalIgnoreCase) &&
                Enum.TryParse(typeof(Permissions), policyName.Substring(ConstantsProject.PrefixPolicy.Length), out var permissionObj))
            {
                var permission = (Permissions)permissionObj!;
                var policy = new AuthorizationPolicyBuilder("Identity.Application");
                policy.AddRequirements(new HavePermissionRequeriment(permission));
                return Task.FromResult<AuthorizationPolicy?>(policy.Build());
            }

            return Task.FromResult<AuthorizationPolicy?>(null!);
        }
    }
}
