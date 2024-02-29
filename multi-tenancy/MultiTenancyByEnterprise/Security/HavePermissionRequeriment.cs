using Microsoft.AspNetCore.Authorization;
using MultiTenancyByEnterprise.Entities;

namespace MultiTenancyByEnterprise.Security
{
    public class HavePermissionRequeriment : IAuthorizationRequirement
    {
        public HavePermissionRequeriment(Permissions permission)
        {
            Permission = permission;
        }

        public Permissions Permission { get; }
    }
}
