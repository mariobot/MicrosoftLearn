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
        [Required(ErrorMessage = "La Categoria es requerida")]
        public int? CategoryId { get; set; }
        [Required(ErrorMessage = "El Nombre es requerido")]
        public string Name { get; set; }
        [Required(ErrorMessage = "La Cantidad es requerida")]
        public int? Quantity { get; set; }
        [Required(ErrorMessage = "El Precio es requerido")]
        public double? Price { get; set; }

        // navegation property for ef core
        public Category Category { get; set; }
    }
}
