using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SystemManagement.Models
{
    public class LPN
    {
        [Key]
        public long LPNId { get; set; }
        [Required]
        public Node Node { get; set; }
    }
}
