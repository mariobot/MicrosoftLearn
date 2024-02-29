using MultiTenancyByEnterprise.Entities;

namespace MultiTenancyByEnterprise.Models
{
    public class PermissionUserDto
    {
        public Permissions Permission { get; set; }
        public bool HaveAccess { get; set; }
        public string? Description { get; set; }
    }
}
