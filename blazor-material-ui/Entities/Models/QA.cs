using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class QA
	{
		public Guid Id { get; set; }
		public string Question { get; set; }
		public string Answer { get; set; }
		[Required(ErrorMessage = "User is required")]
		public string User { get; set; }

		public Guid ProductId { get; set; }
		public Product Product { get; set; }
	}
}
