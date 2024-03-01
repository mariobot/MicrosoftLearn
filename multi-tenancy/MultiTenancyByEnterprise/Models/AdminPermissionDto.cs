namespace MultiTenancyByEnterprise.Models
{
    public class AdminPermissionDto
    {
        public string UserId { get; set; } = null!;
        public string? Email { get; set; }        
        public List<PermissionUserDto> Roles { get; set; } = new List<PermissionUserDto>();
    }
}
