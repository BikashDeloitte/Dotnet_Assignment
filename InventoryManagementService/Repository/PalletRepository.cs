using InventoryManagementService.Models.Dto;
using InventoryManagementService.Repository.Interface;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace InventoryManagementService.Repository
{
    public class PalletRepository : IPalletRepository
    {
        private readonly HttpClient client;
        private readonly ILogger<PalletRepository> _logger;

        public PalletRepository(HttpClient client)
        {
            this.client = client;
        }

        public async Task<IList<PalletDto>> GetAllPallets()
        {
            var response = await client.GetAsync($"/pallet");
            var resp = JsonConvert.DeserializeObject<PalletDto[]>(response.Content.ReadAsStringAsync().Result);
            
            return resp;
        }
    }
}
