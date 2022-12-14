using System.ComponentModel.DataAnnotations;

namespace SystemManagement.Models.Dto
{
    public class NodeDto
    {
        public int NodeId { get; set; }
        public int WarehouseId { get; set; }
        public WarehouseDto Warehouse { get; set; }
        public int roomId { get; set; }
        public int storageNumber { get; set; }
    }
}
