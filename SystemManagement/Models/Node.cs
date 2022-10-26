using System.ComponentModel.DataAnnotations;

namespace SystemManagement.Models
{
    public class Node
    {
        [Key]
        public int NodeId { get; set; }
        [Required]
        public int WarehouseId { get; set; }

        public string WarehouseName { get; set; }
        [Required]
        public int roomId { get; set; }
        public int storageNumber { get; set; }
    }
}
