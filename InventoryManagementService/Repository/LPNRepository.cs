using InventoryManagementService.Models.Dto;
using InventoryManagementService.Repository.Interface;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace InventoryManagementService.Repository
{
    public class LPNRepository : ILPNRepository
    {
       
        private readonly HttpClient client;

        public LPNRepository(HttpClient client)
        {
            this.client = client;
        }
        public async Task<HttpResponseMessage> UpdateLPN(LPNDto lpnDto)
        {
            var myContent = JsonConvert.SerializeObject(lpnDto);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync($"/lpn/", byteContent);
            return response;
        }
    }
}
