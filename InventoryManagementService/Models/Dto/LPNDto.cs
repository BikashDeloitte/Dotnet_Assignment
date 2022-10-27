

namespace InventoryManagementService.Models.Dto
{
    public class LPNDto
    {
        public int LPNId { get; set; }
        public int NodeId { get; set; }
        public NodeDto Node { get; set; }
        public int PalletId { get; set; }
        public PalletDto Pallet { get; set; }
    }
}
