using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemManagement.Models
{
    public class Pallet
    {
        [Key]
        public int PalletId { get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey("Product")]
        public int? ProductId { get; set; }
        
        public virtual Product Product { get; set; }
        [Range(1, 50)]
        public long Quantity { get; set; }

    }
}
