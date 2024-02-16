namespace MultiTenancyByEnterprise.Entities
{
    public class Product : IEntityTenant
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string TenantId { get; set; } = null!;
    }
}
