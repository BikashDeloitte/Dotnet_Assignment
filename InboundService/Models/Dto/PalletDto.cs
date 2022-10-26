using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace InboundService.Models.Dto
{
    public class PalletDto
    {
        [JsonProperty]
        public int PalletId { get; set; }
        [JsonProperty]
        public string Name { get; set; }
        [JsonProperty]
        public int ProductId { get; set; }
        [JsonProperty]
        public ProductDto Product { get; set; }
        [JsonProperty]
        public long Quantity { get; set; }

    }
    /*
    public class PalletList
    {
        [JsonProperty("Pallets")]
        public IList<PalletDto> PalletDtos { get; set; }
    }*/
}
