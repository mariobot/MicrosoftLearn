using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Declaration
	{
		public Guid Id { get; set; }
		[Required(ErrorMessage = "Model is required.")]
		public string Model { get; set; }
		[Required(ErrorMessage = "Origin is required.")]
		public string Origin { get; set; }
		[Required(ErrorMessage = "Customer Rights is required.")]
		public string CustomerRights { get; set; }

		public Guid ProductId { get; set; }
		public Product Product { get; set; }
	}
}
