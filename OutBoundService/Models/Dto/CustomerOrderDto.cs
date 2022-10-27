using System.ComponentModel;

namespace OutBoundService.Models.Dto
{
    public class CustomerOrderDto
    {
        public int CustomerOrderId { get; set; }
        public int CustomerOrderNumber { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
        public string? CreationTime { get; set; }
        public string? ModifiedTime { get; set; }
    }
}
