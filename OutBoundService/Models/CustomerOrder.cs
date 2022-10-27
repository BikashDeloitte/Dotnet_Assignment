using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OutBoundService.Models
{
    public class CustomerOrder
    {
        [Key]
        public int CustomerOrderId { get; set; }
        public int CustomerOrderNumber { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        [DefaultValue("accept")]
        public string Status { get; set; }
        public string? CreationTime { get; set; }
        public string? ModifiedTime { get; set; }
    }
}
