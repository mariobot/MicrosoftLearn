using Microsoft.AspNetCore.Identity;

namespace MultiTenancyByEnterprise.Entities
{
    public class Enterprise : ICommonEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? CreationUserId { get; set; }
        public IdentityUser CreationUser { get; set;} = null!;
        public List<EnterpriseUserPermission> EnterpriseUserPermissions { get; set; } = null!;
    }
}
