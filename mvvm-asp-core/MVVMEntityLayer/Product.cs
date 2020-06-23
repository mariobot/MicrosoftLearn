using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVVMEntityLayer
{
    [Table("Product", Schema ="SalesLT")]  
    public class Product
    {
        public int? ProductID { get; set; }    
        public string Name { get; set; }    
        public string ProductNumber { get; set; }    
        public string Color { get; set; }    
        
        [DataType(DataType.Currency)]    
        [Column(TypeName = "decimal(18, 2)")]    
        public decimal StandardCost { get; set; }    
        
        [DataType(DataType.Currency)]    
        [Column(TypeName = "decimal(18, 2)")]    
        public decimal ListPrice { get; set; }    
        
        public string Size { get; set; }    
        
        [Column(TypeName = "decimal(8, 2)")]    
        public decimal? Weight { get; set; }    
        
        [DataType(DataType.Date)]    
        public DateTime SellStartDate { get; set; }    
        
        [DataType(DataType.Date)]    
        public DateTime? SellEndDate { get; set; }    
        
        [DataType(DataType.Date)]    
        public DateTime? DiscontinuedDate { get; set; }  
    }
}
