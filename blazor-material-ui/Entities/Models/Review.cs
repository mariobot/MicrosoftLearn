using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Review
	{
		public Guid Id { get; set; }
		[Required(ErrorMessage = "User name is required.")]
		public string User { get; set; }
		[Required(ErrorMessage = "Comment is required.")]
		public string Comment { get; set; }
		[Required(ErrorMessage = "Rate is required.")]
		public int Rate { get; set; }

		public Guid ProductId { get; set; }
		public Product Product { get; set; }
	}
}
