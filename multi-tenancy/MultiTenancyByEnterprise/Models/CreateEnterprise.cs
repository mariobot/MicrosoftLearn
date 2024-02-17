using System.ComponentModel.DataAnnotations;

namespace MultiTenancyByEnterprise.Models
{
    public class CreateEnterprise
    {
        [Required(ErrorMessage = "The field {0} is required")]
        public string Name { get; set; } = null!;
    }
}
