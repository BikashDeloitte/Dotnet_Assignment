using InboundService.Models.Dto;
using InboundService.Repository.Interface;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace InboundService.Repository
{
    public class PalletRepository : IPalletRepository
    {
        private readonly HttpClient client;
        private readonly ILogger<PalletRepository> _logger;

        public PalletRepository(HttpClient client)
        {
            this.client = client;
        }
        public async Task<HttpResponseMessage> UpdatePallet(PalletDto palletDto)
        {
            var myContent = JsonConvert.SerializeObject(palletDto);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync($"/pallet/", byteContent);
            return response;
        }

        public async Task<long> GetPalletByProductId(int id)
        {
            long productQuantities = 0;
            var response = await client.GetAsync($"/product/quantity/{id}");
            var resp = JsonConvert.DeserializeObject<PalletDto[]>(response.Content.ReadAsStringAsync().Result);
            foreach(PalletDto palletDto in resp)
            {
                productQuantities += palletDto.Quantity;
            }
            return productQuantities;
        }
    }
}
