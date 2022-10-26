using InboundService.Models.Dto;
using InboundService.Repository.Interface;
using Newtonsoft.Json;

namespace InboundService.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly HttpClient client;

        public ProductRepository(HttpClient client)
        {
            this.client = client;
        }
        public async Task<ProductDto> GetProduct(int id)
        {
            var response = await client.GetAsync($"/api/product/{id}");
            var apiContent = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<ProductDto>(apiContent);
            if (resp != null)
            {
                return resp;
            }
            return new ProductDto();
        }
    }
}
