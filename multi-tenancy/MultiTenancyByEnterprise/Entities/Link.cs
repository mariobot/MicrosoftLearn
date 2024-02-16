using Microsoft.AspNetCore.Identity;

namespace MultiTenancyByEnterprise.Entities
{
    public class Link : ICommonEntity
    {
        public int Id { get; set; }
        public Guid EnterpriseId { get; set; }
        public string UserId { get; set; } = null!;
        public LinkStatus Status { get; set; }
        public DateTime CreationDate { get; set; }
        public Enterprise Enterprise { get; set; } = null!;
        public IdentityUser User { get; set; } = null!;
    }
}
