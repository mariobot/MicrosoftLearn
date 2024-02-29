using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MultiTenancyByEnterprise.Data;
using MultiTenancyByEnterprise.Services;

namespace MultiTenancyByEnterprise.Security
{
    public class HavePermissionHandle : AuthorizationHandler<HavePermissionRequeriment>
    {
        private readonly IServiceTenant serviceTenant;
        private readonly IUserService userService;
        private readonly ApplicationDbContext dbContext;

        public HavePermissionHandle(IServiceTenant serviceTenant,
            IUserService userService,
            ApplicationDbContext dbContext)
        {
            this.serviceTenant = serviceTenant;
            this.userService = userService;
            this.dbContext = dbContext;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, HavePermissionRequeriment requirement)
        {
            var permission = requirement.Permission;
            var userId = userService.GetUserId();
            var tenantId = new Guid(serviceTenant.GetTenant());

            var havePermission = await dbContext.EnterpriseUserPermissions
                .AnyAsync(x => x.User.Id == userId
                && x.EnterpriseId == tenantId
                && x.Permission == permission);

            if (havePermission)
            {
                context.Succeed(requirement);
            }
        }
    }
}
