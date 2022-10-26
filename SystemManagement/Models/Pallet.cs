using System.ComponentModel.DataAnnotations;

namespace SystemManagement.Models
{
    public class Pallet
    {
        [Key]
        public int PalletId { get; set; }
        [Required]
        public string Name { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Range(1, 50)]
        public long Quantity { get; set; }

    }
}
