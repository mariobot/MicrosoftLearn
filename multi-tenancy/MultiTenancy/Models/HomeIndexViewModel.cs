using MultiTenancy.Entities;

namespace MultiTenancy.Models
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Product> prodructs { get; set; } = new List<Product>();
        public IEnumerable<Country> contries { get; set; } = new List<Country>();
    }
}
