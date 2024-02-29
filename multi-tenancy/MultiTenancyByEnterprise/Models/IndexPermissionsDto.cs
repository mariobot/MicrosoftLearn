namespace MultiTenancyByEnterprise.Models
{
    public class IndexPermissionsDto
    {
        public string NameEnterprise { get; set; } = null!;
        public IEnumerable<UserDto> Users { get; set; } = null!;
    }
}
