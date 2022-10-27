using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace SystemManagement.Models
{
    public class LPN
    {
        [Key]
        public int LPNId { get; set; }
        [ForeignKey("Node")]
        public int NodeId { get; set; }
        
        public Node Node { get; set; }
        [ForeignKey("Pallet")]
        public int PalletId { get; set; }
        public Pallet Pallet { get; set; }
    }
}
