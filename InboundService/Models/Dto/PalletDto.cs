namespace InboundService.Models.Dto
{
    public class PalletDto
    {
        
        public int PalletId { get; set; }
        
        public string Name { get; set; }
       
        public int ProductId { get; set; }
        
        public ProductDto Product { get; set; }
        
        public long Quantity { get; set; }

    }
    /*
    public class PalletList
    {
        [JsonProperty("Pallets")]
        public IList<PalletDto> PalletDtos { get; set; }
    }*/
}
