using InventoryManagementService.Models.Dto;
using InventoryManagementService.Repository.Interface;
using Newtonsoft.Json;

namespace InventoryManagementService.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly HttpClient client;

        public ProductRepository(HttpClient client)
        {
            this.client = client;
        }
        public async Task<IList<ProductDto>> GetAllProduct()
        {
            var response = await client.GetAsync($"/product");
            var resp = JsonConvert.DeserializeObject<ProductDto[]>(response.Content.ReadAsStringAsync().Result);

            return resp;
        }

        
    }
}
