using System.ComponentModel.DataAnnotations;

namespace SystemManagement.Models
{
    public class Pallet
    {
        [Key]
        public long PalletId { get; set; }
        [Required]
        public string Name { get; set; }
        public Product Product { get; set; }
        [Range(1, 50)]
        public long Quantity { get; set; }

    }
}
