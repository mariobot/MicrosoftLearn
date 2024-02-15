namespace MultiTenancy.Entities
{
    public class Contry : ICommonEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
