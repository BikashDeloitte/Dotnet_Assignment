using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemManagement.Models
{
    public class Node
    {
        [Key]
        public int NodeId { get; set; }
        [ForeignKey("Warehouse")]
        public int WarehouseId { get; set; }   
        [Required]
        public Warehouse Warehouse { get; set; }
        [Required]
        public int RoomId { get; set; }
        public int StorageNumber { get; set; }
    }
}
