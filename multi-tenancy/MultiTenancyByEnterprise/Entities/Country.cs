namespace MultiTenancyByEnterprise.Entities
{
    public class Country : ICommonEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
