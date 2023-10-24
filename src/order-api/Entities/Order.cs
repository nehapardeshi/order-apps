using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderAPI.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string ?OrderNumber { get; set; }
        public string ?CustomerNumber { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; } = 0;
        public DateTime OrderDate { get; set; }

        public DateTime CreatedDate { get; set; }
        public List <OrderLine> OrderLines { get; set; } = new List <OrderLine> ();


    }
}
