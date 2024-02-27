using Microsoft.AspNetCore.Authorization;
using MultiTenancyByEnterprise.Entities;
using MultiTenancyByEnterprise.Services;
using System.Security.Claims;

namespace MultiTenancyByEnterprise.Security
{
    public static class IAuthorizationServiceExtension
    {
        public static async Task<bool>
            HavePermission(this IAuthorizationService authorizationService,
            ClaimsPrincipal user,
            Permissions permission)
        { 
            if (!user.Identity!.IsAuthenticated) 
            { 
                return false;
            }

            var policyName = $"{ConstantsProject.PrefixPolicy}{permission}";
            var result = await authorizationService.AuthorizeAsync(user, policyName);

            return result.Succeeded;
        }
    }
}
