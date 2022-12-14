using System.ComponentModel.DataAnnotations;

namespace SystemManagement.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        [Range(1,10)]
        public int Priority { get; set; }
    }
}
