using InboundService.Models.Dto;
using InboundService.Repository.Interface;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace InboundService.Repository
{
    public class PalletRepository : IPalletRepository
    {
        private readonly HttpClient client;

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
    }
}
