using System.ComponentModel.DataAnnotations;

namespace InboundService.Models.Dto 
{ 
    public class PalletDto
    {
        public long PalletId { get; set; }
        public string Name { get; set; }
        public ProductDto Product { get; set; }
        public long Quantity { get; set; }

    }
}
