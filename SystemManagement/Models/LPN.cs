using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SystemManagement.Models
{
    public class LPN
    {
        [Key]
        public int LPNId { get; set; }
        public int NodeId { get; set; }
        
        public Node Node { get; set; }
        public int PalletId { get; set; }
        public Pallet Pallet { get; set; }
    }
}
