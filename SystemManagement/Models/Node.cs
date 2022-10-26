using System.ComponentModel.DataAnnotations;

namespace SystemManagement.Models
{
    public class Node
    {
        [Key]
        public int NodeId { get; set; }
        [Required]
        public Warehouse Warehouse { get; set; }
        [Required]
        public int RoomId { get; set; }
        public int StorageNumber { get; set; }
    }
}
