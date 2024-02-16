using Microsoft.AspNetCore.Identity;

namespace MultiTenancyByEnterprise.Entities
{
    public class EnterpriseUserPermission : ICommonEntity
    {
        public string UserId { get; set; } = null!;
        public Guid EnterpriseId { get; set; }
        public Permissions Permission { get; set; }
        public IdentityUser? User { get; set; }
        public Enterprise? Enterprise { get; set; }
    }
}
