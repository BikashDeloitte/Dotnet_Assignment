using System.ComponentModel.DataAnnotations;

namespace InboundService.Models.Dto
{
    public class NodeDto
    {
        public int NodeId { get; set; }
        public WarehouseDto warehouse { get; set; }
        public int roomId { get; set; }
        public int storageNumber { get; set; }
    }
}
