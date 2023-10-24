using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderAPI.Entities
{
    public class OrderLine
    {
        [Key]
        public int Id { get; set; }
        public int ItemNumber { get; set; }
        public int Quantity { get; set; }
        [Column (TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int OrderId { get; set; } //FK
        public Order ?Order { get; set; } 

    }
}
