using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MultiTenancyByEnterprise.Data;
using System.Security.Claims;

namespace MultiTenancyByEnterprise.Services
{
    public class ChangeTenantService : IChangeTenantService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ApplicationDbContext context;

        public ChangeTenantService(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
        }

        public async Task ReplaceTenant(Guid enterpriseId, string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            var existingClaimTenant = await context.UserClaims
                .FirstOrDefaultAsync(x => x.ClaimType == ConstantsProject.ClaimTenantId && x.UserId == userId);

            if (existingClaimTenant is not null) 
            {
                context.Remove(existingClaimTenant);
            }

            var newClaimTenant = new Claim(ConstantsProject.ClaimTenantId, enterpriseId.ToString());

            await userManager.AddClaimAsync(user, newClaimTenant);

            await signInManager.SignInAsync(user, isPersistent: true);            
        }
    }
}
