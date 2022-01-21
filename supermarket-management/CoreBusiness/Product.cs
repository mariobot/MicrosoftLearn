using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "La Categoria es requerido")]
        public int? CategoryId { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Name { get; set; }
        [Required(ErrorMessage = "La cantidad es requerida")]
        public int? Quantity { get; set; }
        [Required(ErrorMessage = "El precio es requerido")]
        public double? Price { get; set; }
    }
}
