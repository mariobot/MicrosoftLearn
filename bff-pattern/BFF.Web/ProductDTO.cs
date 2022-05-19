using System.Text.Json.Serialization;

namespace BFF.Web
{
    public class ProductDTO
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
