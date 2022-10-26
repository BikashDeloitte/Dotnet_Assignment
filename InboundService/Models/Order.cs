using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InboundService.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int OrderNumber { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        [DefaultValue("accept")]
        public string Status { get; set; }
    }
}
