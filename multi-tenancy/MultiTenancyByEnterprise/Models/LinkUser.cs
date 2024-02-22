namespace MultiTenancyByEnterprise.Models
{
    public class LinkUser
    {
        public Guid EnterpriseId { get; set; }
        public string EnterpriseName { get; set; } = null!;
        public string EmailUser { get; set; } = null!;
    }
}
